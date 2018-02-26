using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

  public LayerMask floorOnly;
  public Transform player;
  Vector3 moveDirection = Vector3.zero;

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    if (Physics.Raycast(transform.position, player.position - transform.position))
    {
      moveDirection = player.position - transform.position;
      transform.forward = moveDirection;
    }
  }
}
