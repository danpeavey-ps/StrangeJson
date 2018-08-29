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
    
        protected override void mapBindings()
        {
            base.mapBindings();

            injectionBinder.Bind<Transform>()
                .ToValue(appContextView.generatedContentLocation)
                .ToName(AppInjectionKeys.GeneratedContentLocation);
            
            injectionBinder.Bind<IViewAssetMap>()
                .ToValue(Resources.Load<ViewPrefabMap>("ViewPrefabMap"))
                .ToName(AppInjectionKeys.ViewPrefabMap);
            
            injectionBinder.Bind<IStateModel>().To<AppState>().ToSingleton();
            injectionBinder.Bind<ThrowDebugSignal>().ToSingleton();
            commandBinder.Bind<ThrowDebugSignal>().To<ThrowDebugCommand>();
            commandBinder.Bind<CreateViewSignal>().To<CreateViewCommand>();
            mediationBinder.Bind<SimpleGeneratedView>()
                .ToAbstraction<IGeneratedView>()
                .To<GeneratedMediator>();

            // injectionBinder.ConsumeBindings();
            // mediationBinder.ConsumeBindings();
            // commandBinder.ConsumeBindings();
        }
    
        public override void Launch()
        {
            base.Launch();

            var debugMessageSignal = injectionBinder.GetInstance<ThrowDebugSignal>();

            var list = injectionBinder.GetInstance<IViewAssetMap>(AppInjectionKeys.ViewPrefabMap).ViewAssets;
            var lastInList = list.Last();
            
            StringBuilder message = new StringBuilder();
            message.Append("Retriving all listed prefabs in ViewPrefabMap: ");
            foreach (var asset in list)
            {
                message.Append(asset.ViewType.Name);

                if (asset != lastInList)
                    message.Append(", ");
                else
                    message.Append(".");
            }

            debugMessageSignal.Dispatch(message.ToString());
        }
    }
}