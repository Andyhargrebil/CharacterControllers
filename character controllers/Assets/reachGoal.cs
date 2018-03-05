using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reachGoal : MonoBehaviour {

  private Animator whatever;

	// Use this for initialization
	void Start () {
    whatever = GameObject.Find ("Ethan").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider hits){
		GameObject.Find ("Ghost").GetComponent<FirstPersonControls> ().canMove = false;
    whatever.SetBool("IsMoving", true);
	}
}
