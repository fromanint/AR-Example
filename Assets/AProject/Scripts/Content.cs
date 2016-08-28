using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BundleLoad))]
public class Content : MonoBehaviour {

	public bool UI;
	public bool stay;
	public string contentName;

	[SerializeField] GameObject uiContent;


	Vector3 startScale;
	Quaternion startRotation;
	Vector3 startPostion;
	// Use this for initialization
	void OnEnable () {
		GetComponent<BundleLoad> ().contentName = contentName;
		GetComponent<BundleLoad> ().ReadBundle ();
		startScale = transform.localScale;
		startRotation = transform.localRotation;
		startPostion = transform.localPosition;
		if (UI) {
			uiContent.SetActive (true);
		}
	    
	}
	


	public void ContentReset(){
		transform.localPosition = startPostion;
		transform.localRotation = startRotation;
		transform.localScale = startScale;
	}

	public void RotateObject(Vector3 rotation){

		transform.Rotate(rotation);
	}
		

	public void Zoom(float zoom){
		float x = zoom + transform.localScale.x;
		float y = zoom + transform.localScale.y;
		float z = zoom + transform.localScale.z;
		transform.localScale = new Vector3(x,y,z);
	}

	public void Move(Vector3 newPosition)
	{
		transform.position += newPosition;
	}

	public void Hide(){
		foreach (Transform trans in transform) {
			Destroy (trans.gameObject);
		}
		uiContent.SetActive (false);
		gameObject.SetActive (false);
	}

}
