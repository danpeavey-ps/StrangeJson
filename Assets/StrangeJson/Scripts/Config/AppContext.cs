using strange.extensions.context.impl;
using UnityEngine;

namespace StrangeJson
{
    public class AppContext : MVCSContext
    {
        public AppContext(MonoBehaviour view) : base(view, true)
        {
        }
    
        protected override void mapBindings()
        {
            base.mapBindings();
            
            injectionBinder.Bind<IStateModel>().To<AppState>().ToSingleton();
            injectionBinder.Bind<ThrowDebugSignal>().ToSingleton();
            commandBinder.Bind<ThrowDebugSignal>().To<ThrowDebugCommand>();
            commandBinder.Bind<CreateViewSignal>().To<CreateViewCommand>();
            mediationBinder.Bind<SimpleGeneratedView>().ToAbstraction<IGeneratedView>().To<GeneratedMediator>();

            // injectionBinder.ConsumeBindings();
            // mediationBinder.ConsumeBindings();
            // commandBinder.ConsumeBindings();
        }
    
        public override void Launch()
        {
            base.Launch();
        }
    }
}