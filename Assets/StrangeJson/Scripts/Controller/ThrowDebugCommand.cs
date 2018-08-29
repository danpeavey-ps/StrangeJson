using strange.extensions.command.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace StrangeJson
{
    public class ThrowDebugCommand : Command
    {   
        [Inject]
        private string debugMessage { get; set; }
    
        public override void Execute()
        {
            Debug.Log(debugMessage);
        }
    }
}