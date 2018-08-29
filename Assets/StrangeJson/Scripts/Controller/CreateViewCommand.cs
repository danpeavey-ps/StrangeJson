using UnityEngine;
using strange.extensions.command.impl;

namespace StrangeJson
{
    public class CreateViewCommand : Command
    {
        [Inject(AppInjectionKeys.GeneratedContentLocation)]
        private Transform instantiationTarget { get; set; }

        [Inject]
        private IGeneratedView generatedView { get; set; }
        
        [Inject]
        private IViewAssetMap viewAssetMap { get; set; }

        public override void Execute()
        {
            Debug.Log("Creating a view!");

        }
    }
}