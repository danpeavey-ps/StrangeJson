using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace StrangeJson
{
	[Serializable]
	public struct ViewAsset : IViewAsset
	{
		[SerializeField]
		private UnityEngine.Object viewPrefab;

		public Type ViewType 
		{ 
			get 
			{
				GameObject viewPrefab = ViewPrefab as GameObject;
				View view = viewPrefab.GetComponentsInChildren<View>(true).First();
				string viewType = view.GetType().Name;

				Assembly assembly = Assembly.GetExecutingAssembly();
				string typeDef = string.Format(
					"{0}.{1}, {2}",
					"StrangeJson",
					viewType,
					assembly.FullName 
				);
				return Type.GetType(typeDef);
			}
		}
		public UnityEngine.Object ViewPrefab 
		{ 
			get 
			{
				return viewPrefab;
			} 
		}
	}

	[CreateAssetMenu(menuName = "StrangeJson/Create View Prefab Map", fileName = "ViewPrefabMap.asset", order = 1)]
    public class ViewPrefabMap : ScriptableObject, IViewAssetMap
    {
		[SerializeField]
		private List<ViewAsset> viewAssets = new List<ViewAsset>();

        public IList<IViewAsset> ViewAssets
        {
            get
            {
				return viewAssets.Cast<IViewAsset>().ToList();
            }
        }
    }
}