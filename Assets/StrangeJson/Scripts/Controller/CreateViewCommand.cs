using UnityEngine;
using strange.extensions.command.impl;

namespace StrangeJson
{
    public class CreateViewCommand : Command
    {
        [Inject]
        private IGeneratedView generatedView { get; set; }

        public override void Execute()
        {
            Debug.Log("Creating a view!");
        }
    }
}