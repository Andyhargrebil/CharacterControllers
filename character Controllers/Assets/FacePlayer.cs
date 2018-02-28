using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

  public LayerMask floorOnly;
  public Transform player;

  // Use this for initialization
  void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    RaycastHit hitInfo;
    if (Physics.Raycast(transform.position, player.position - transform.position, out hitInfo, floorOnly))
    {
      if(hitInfo.transform.gameObject.tag == "Player")
      {
        transform.forward = player.position - transform.position;
      }
    }
  }
}
