using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRotate : MonoBehaviour {

    public float rotationSpeed = 360f; // Degrees per second

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
	}
}
