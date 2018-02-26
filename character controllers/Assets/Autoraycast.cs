using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoraycast : MonoBehaviour
{

  public LayerMask raycastLayers;
  public LayerMask floorOnly;

  public Transform Leader;

  public float speed = 4.0f;

  public float rayDistance = 3.0f;

  private float dist;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    Vector3 moveDirection = Vector3.zero;

    RaycastHit hitInfo;
    if (Physics.Raycast(transform.position, Leader.position - transform.position, out hitInfo, rayDistance, raycastLayers.value))
    {
      if (Vector3.Distance(Leader.position, transform.position) > 2)
      {
        moveDirection = Leader.position - transform.position;
        transform.position += moveDirection * speed * Time.deltaTime;
      }

    }

    if (Input.GetMouseButtonDown(0))
    {
      Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
      if (Physics.Raycast(intoScreen, out hitInfo, 1000, floorOnly))
      {
        transform.position = hitInfo.point + new Vector3(0, 1, 0);
      }
    }
  }
}
