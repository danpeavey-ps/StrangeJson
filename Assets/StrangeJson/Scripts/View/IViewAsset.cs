using System;
using UnityEngine;

namespace StrangeJson
{
    public interface IViewAsset
    {
        Type ViewType { get; }
        UnityEngine.Object ViewPrefab { get; }
    }
}