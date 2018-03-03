using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBulletScript : MonoBehaviour {
	float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer = timer + Time.deltaTime;
		if (timer > 5.0f)
			Destroy (gameObject);
	}
}
