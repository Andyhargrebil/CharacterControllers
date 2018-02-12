using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetoMouse : MonoBehaviour {

    public LayerMask floorOnly;
    public float speed = 4.0f;
    private Vector3 whereClick;

    // Use this for initialization
    void Start () {
        whereClick = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hitInfo;

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
        {
            Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(intoScreen, out hitInfo, 1000, floorOnly))
            {
                whereClick = hitInfo.point + new Vector3(0, 0.5f, 0);
            }
        }

        if (Vector3.Distance(whereClick, transform.position) < 0.1)
        {
            whereClick = transform.position;
        }

        moveDirection = whereClick - transform.position;
        moveDirection.Normalize();
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
