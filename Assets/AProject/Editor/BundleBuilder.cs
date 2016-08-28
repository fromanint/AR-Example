using UnityEngine;
using UnityEditor;

public class BundleBuilder : Editor {

    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundle()
    {
        BuildPipeline.BuildAssetBundles("AssetBundle");
		BuildPipeline.BuildAssetBundles ("AssetBundle/Android", BuildAssetBundleOptions.None, BuildTarget.Android);
    }

}
