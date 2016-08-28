using UnityEngine;
using System.Collections;

public class TestJsonContent : MonoBehaviour {

	[SerializeField] Content content;
	[SerializeField] string URL;
	// Use this for initialization
	IEnumerator LoadJson()
	{
		WWW www = new WWW(URL);
		Debug.Log (URL);
		yield return www;
		if (www.error == null) {
			Debug.Log ("JSON: " + www.text);
			GetComponent<JsonContent> ().ChangeContent (www.text);
		} else {
			Debug.Log ("Error: " + www.error);
		}

	}

	void Start()
	{
		StartCoroutine ("LoadJson");
	}
}
