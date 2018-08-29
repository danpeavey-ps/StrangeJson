using strange.extensions.mediation.api;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;

namespace StrangeJson
{   
    public interface ISimpleGeneratedView : IGeneratedView
    {
        void UpdateText(string message);
    }

    public class SimpleGeneratedView : View, ISimpleGeneratedView
    {
        [SerializeField]
        private TextMeshProUGUI text;

        protected override void Start()
        {
            base.Start();
            text.text = "";
        }

        public void UpdateText(string message)
        {
            text.text = message;
        }
    }
}