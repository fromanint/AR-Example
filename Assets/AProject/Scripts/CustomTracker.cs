using UnityEngine;
using System.Collections;
using Vuforia;

public class CustomTracker : MonoBehaviour,ITrackableEventHandler{



		#region PRIVATE_MEMBERS
		private TrackableBehaviour mTrackableBehaviour;
		#endregion // PRIVATE_MEMBERS

	[SerializeField]Content setContent;
	    bool first;
		#region MONOBEHAVIOUR_METHODS
		void Start()
		{
		first = false;
			mTrackableBehaviour = GetComponent<TrackableBehaviour>();
			if (mTrackableBehaviour)
			{
				mTrackableBehaviour.RegisterTrackableEventHandler(this);
			}
			setContent = FindObjectOfType<Content> ();
		if (!setContent) {
			Debug.Log ("No Content Manager Found :(");
		} else {
			Debug.Log (":D Content manager found yei!!!");
		}
		setContent.Hide ();
		}
		#endregion //MONOBEHAVIOUR_METHODS


		#region PUBLIC_METHODS
		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
			TrackableBehaviour.Status previousStatus,
			TrackableBehaviour.Status newStatus)
		{
			if (newStatus == TrackableBehaviour.Status.DETECTED ||
				newStatus == TrackableBehaviour.Status.TRACKED ||
				newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
			{
				OnTrackingFound();
			}
			else if (previousStatus == TrackableBehaviour.Status.UNKNOWN &&
				newStatus == TrackableBehaviour.Status.NOT_FOUND)
			{
				// Ignore this specific combo
				return;
			}
			else
			{
				OnTrackingLost();
			}
		}
		#endregion //PUBLIC_METHODS


		#region PRIVATE_METHODS
		private void OnTrackingFound()
		{

		setContent.gameObject.SetActive (true);
		setContent.transform.parent = gameObject.transform;
		setContent.ContentReset ();

        // Stop finder since we have now a result, finder will be restarted again when we lose track of the result
        ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        if (objectTracker != null)
        {
            objectTracker.TargetFinder.Stop();
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
		}

		private void OnTrackingLost()
		{
		if (!setContent) {
			setContent = FindObjectOfType<Content> ();
		} 
		if (setContent.stay) {
			setContent.transform.parent = Camera.main.transform.FindChild ("ContentParent");
			setContent.ContentReset ();
		} else {
			setContent.Hide ();
		}
        	// Start finder again if we lost the current trackable
       		 ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
       		 if (objectTracker != null)
			{
             	objectTracker.TargetFinder.ClearTrackables(false);
           	 	objectTracker.TargetFinder.StartRecognition();
      	   	}
        	Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		}
		#endregion //PRIVATE_METHODS


}
