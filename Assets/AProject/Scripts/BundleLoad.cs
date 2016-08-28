using UnityEngine;
using System.Collections;

public class BundleLoad : MonoBehaviour {

    [SerializeField]  string bundleUrl;
    AssetBundle assetBundle;

	[HideInInspector]public string contentName;

    
	IEnumerator LoadAsset()
    {
        WWW www = new WWW(bundleUrl);
		Debug.Log (bundleUrl);
        yield return www;
        assetBundle = www.assetBundle;
        if (!assetBundle)
        {
            Debug.Log("no asset bundle :(");
        }
        else {
			GameObject newObj = Instantiate (assetBundle.LoadAsset(contentName)) as GameObject;
			if (newObj) {
				newObj.transform.SetParent (gameObject.transform);
				newObj.transform.localPosition = Vector3.zero;
				newObj.transform.localRotation = Quaternion.identity;
				newObj.transform.localScale = new Vector3 (1, 1, 1);
				Debug.Log (name);
			} else {
				Debug.Log (name + "Not found in the Bundle");
			}

        }
    }


	public  void ReadBundle () {
        StartCoroutine("LoadAsset");
	}
	

}
