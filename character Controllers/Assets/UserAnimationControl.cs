using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserAnimationControl : MonoBehaviour {

    public bool isCharacterMoving;
    private Animator whatever;

	// Use this for initialization
	void Start () {
        whatever = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        whatever.SetBool("IsMoving", isCharacterMoving);
	}
}
