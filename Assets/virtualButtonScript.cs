using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class virtualButtonScript : MonoBehaviour,IVirtualButtonEventHandler {
	private GameObject virtualButtonObject;


	// Use this for initialization
	void Start () {
		virtualButtonObject = GameObject.Find ("VirtualButton");
		virtualButtonObject.GetComponent<VirtualButtonBehaviour> ().RegisterEventHandler (this);

	}
	
	// Update is called once per frame
	public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
	{
		Debug.Log ("Button Press ");

	}

	public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
	{
		
	}
}
