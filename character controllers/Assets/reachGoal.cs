using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachGoal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider hits){
		GameObject.Find ("Ghost").GetComponent<FirstPersonControls> ().canMove = false;
	}
}
