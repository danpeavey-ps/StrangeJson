using System.Linq;
using System.Text;
using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace StrangeJson
{
    public class OutputAssetMapContentsCommand : Command
    {   
        [Inject(AppInjectionKeys.ViewPrefabMap)]
        private IViewAssetMap assetMap { get; set; }

        [Inject]
        private IStateModel appState { get; set; }
    
        public override void Execute()
        {
            var lastInList = assetMap.ViewAssets.Last();
            
            StringBuilder message = new StringBuilder();
            message.AppendFormat("Current state: {0}", appState.stateMessage);
            message.AppendLine("Retriving all listed prefabs in ViewPrefabMap: ");
            foreach (var asset in assetMap.ViewAssets)
            {
                message.Append(asset.ViewType.Name);

                if (asset != lastInList)
                    message.Append(", ");
                else
                    message.Append(".");
            }

            Debug.Log(message);
        }
    }
}