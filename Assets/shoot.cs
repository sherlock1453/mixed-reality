using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class shoot : MonoBehaviour,ITrackableEventHandler {
	public GameObject bullet;
	public Transform gunTransform;
	private bool isTracked;
	private TrackableBehaviour trackable;
	private float timer;

	// Use this for initialization
	void Start () {
		isTracked = false;
		trackable = GetComponent<TrackableBehaviour> ();
		trackable.RegisterTrackableEventHandler (this);
		CameraDevice.Instance.SetFlashTorchMode (true);
		timer = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
		
		timer = timer + Time.deltaTime;
		if (isTracked == true) 
		{
			
			if (timer >= 2.0f)
			{	
				Debug.Log ("shoot");
				timer = 0.0f;
				GameObject clone = Instantiate (bullet, gunTransform.position,Quaternion.identity);
				clone.GetComponent<Rigidbody> ().AddForce (-transform.up.normalized*5000.0f);
			}
			gunDirectionChange ();

		}
	}

	private void gunDirectionChange()
	{
		Ray bulletRay = new Ray (gunTransform.position, -transform.up.normalized);
		RaycastHit hitInfo;
		if (Physics.Raycast (bulletRay, out hitInfo))
			gunTransform.LookAt (hitInfo.point);
	}

	public void OnTrackableStateChanged(TrackableBehaviour.Status prev , TrackableBehaviour.Status news)
	{
		if (news == TrackableBehaviour.Status.DETECTED || news == TrackableBehaviour.Status.TRACKED)
			isTracked = true;

		 else
			isTracked = false;
}
}
