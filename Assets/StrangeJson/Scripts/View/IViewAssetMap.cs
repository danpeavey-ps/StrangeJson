using System.Collections.Generic;

namespace StrangeJson
{
    public interface IViewAssetMap
    {
        IList<IViewAsset> ViewAssets { get; }
    }
}