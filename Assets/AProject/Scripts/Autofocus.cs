using System.Collections;
using UnityEngine;
using Vuforia;


public class Autofocus : MonoBehaviour {

		// Use this for initialization
		/*void Start () {
			bool success = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
			if (success) {
				Debug.Log("Successfully set the continuous autofocus");
			}
			else {
				Debug.Log("Unable to set the continuous autofocus");
			}
			//mEnableAutofocus = false;
			
		}
		
		// Update is called once per frame
		void Update () {

		}*/


 float clicked = 0;
 float clicktime = 0;
 float clickdelay = 0.5f;
 
 void Update(){
         if (Input.GetMouseButtonDown (0)) {
             clicked++;
             if (clicked == 1) clicktime = Time.time;
         }         
         if (clicked > 1 && Time.time - clicktime < clickdelay) {
             clicked = 0;
			bool success = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
			if (success) {
				Debug.Log("Successfully set the continuous autofocus");
			}
			else {
				Debug.Log("Unable to set the continuous autofocus");
			}
           

         } else if (clicked > 2 || Time.time - clicktime > 1)
			clicked = 0;         
         
     }
 	
		
		

}


