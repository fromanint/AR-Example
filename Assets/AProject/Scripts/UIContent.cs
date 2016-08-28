using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIContent : MonoBehaviour {

	[SerializeField] Content setContent;
	// Use this for initialization

	[SerializeField] Scrollbar rotateX;
	[SerializeField] Scrollbar rotateY;
    

	public void ContentReset()
	{
		setContent.ContentReset ();
	}

	public void RotateContent(){
		Vector3 rotation;
		float y;
		float x;

		y = ((rotateY.value - .5f)*360)/.5f;
		x = ((rotateX.value - .5f)*360)/.5f;

		setContent.RotateObject(new Vector3(x,y,0));
	}

	public void MoveContentX(float x){
		
		setContent.Move(new Vector3(x,0,0));
	}

	public void MoveContentY(float y){
		setContent.Move(new Vector3(0,y,0));
	}
}
