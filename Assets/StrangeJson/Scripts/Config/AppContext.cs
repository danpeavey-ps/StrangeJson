using System.Collections.Generic;
using System.Linq;
using System.Text;
using strange.extensions.context.impl;
using UnityEngine;

namespace StrangeJson
{
    public class AppContext : MVCSContext
    {
        private AppContextView appContextView;

        public AppContext(MonoBehaviour view) : base(view, true)
        {
            appContextView = (AppContextView)view;
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            // Generate whitelist for injections.
            // Technically there is nothing stopping us from making
            // this whitelist configurable too via some schema.
            List<object> injectionWhiteList = new List<object>()
            {
                typeof(IStateModel),
                typeof(AppState),
                typeof(DebugAppState)
            };
            Debug.LogFormat("TESTING THIS:: {0}", System.Type.GetType(typeof(DebugAppState).FullName).FullName);
            injectionBinder.WhitelistBindings(injectionWhiteList);
        }
    
        protected override void mapBindings()
        {
            base.mapBindings();


            // Base App Bindings
            injectionBinder.Bind<Transform>()
                .ToValue(appContextView.generatedContentLocation)
                .ToName(AppInjectionKeys.GeneratedContentLocation);
            
            injectionBinder.Bind<IViewAssetMap>()
                .ToValue(Resources.Load<ViewPrefabMap>("ViewPrefabMap"))
                .ToName(AppInjectionKeys.ViewPrefabMap);
            
            injectionBinder.Bind<IStateModel>().To<AppState>().ToSingleton().Weak();
            commandBinder.Bind<CreateViewSignal>().To<CreateViewCommand>();
            commandBinder.Bind<OutputAssetMapContentsSignal>().To<OutputAssetMapContentsCommand>();
            mediationBinder.Bind<SimpleGeneratedView>()
                .ToAbstraction<IGeneratedView>()
                .To<GeneratedMediator>();
            
            // "Configurable Bindings" from an Application Response.
            var injectionBindings = Resources.Load<TextAsset>("BaseInjectionBindings").text;
            injectionBinder.ConsumeBindings(injectionBindings);

            // mediationBinder.ConsumeBindings();
            // commandBinder.ConsumeBindings();
        }
    
        public override void Launch()
        {
            base.Launch();

            var outputSignal = injectionBinder.GetInstance<OutputAssetMapContentsSignal>();
            outputSignal.Dispatch();
        }
    }
}