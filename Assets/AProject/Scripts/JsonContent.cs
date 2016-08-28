using UnityEngine;
using LitJson;


public class JsonContent : MonoBehaviour{

	public string ContentName;
	public bool Stay;
	public bool UI;

	public void ChangeContent(string json)
	{
		JsonData content = JsonMapper.ToObject (json);
		ContentName = content ["ContentName"].ToString ();
		if (content ["UI"].ToString () == "True") {
			UI = true;
			} else {
			UI = false;
		}
		Debug.Log (content ["Stay"].ToString ());
		if (content ["Stay"].ToString () == "True") {
			Stay = true;
		} else {
			Stay = false;
		}
	}
}
