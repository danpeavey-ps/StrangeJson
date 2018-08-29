using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

namespace StrangeJson
{
	public class AppContextView : ContextView
	{
		public Transform generatedContentLocation;

	    private void Awake()
		{
			context = new AppContext(this);
			context.Start();
		}
	}
}
