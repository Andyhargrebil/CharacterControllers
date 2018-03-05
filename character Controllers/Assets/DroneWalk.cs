using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWalk : MonoBehaviour {

  public LayerMask floorOnly;
  public Transform player;
  public GameObject ammo;
  public float speed = 4.0f;
  private Vector3 moveDirection;
  private bool foundYou;
  private Vector3 playerPos;

  // Use this for initialization
  void Start () {
    moveDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

    RaycastHit hitInfo;

    if (Physics.Raycast(transform.position, player.position - transform.position, out hitInfo, floorOnly))
    {
      if (hitInfo.transform.gameObject.tag == "Player")
      {
        foundYou = true;
        transform.forward = player.position - transform.position;
        Instantiate(ammo, transform.position, transform.rotation);      
      }
    } else { foundYou = false; }

    if (foundYou == true)
    {
      moveDirection = player.position + new Vector3(0, 1f, 0) - transform.position;
      moveDirection.Normalize();
      transform.position += moveDirection * speed * Time.deltaTime;
    }
  }
}
