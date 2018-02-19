using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getClick : MonoBehaviour {

    public movetoMouse controlledAI;
    public LayerMask floorOnly;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 1000, floorOnly))
            {
                controlledAI.Seek(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray intoScreen = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(intoScreen, out hitInfo, 1000, floorOnly))
            {
                controlledAI.Flee(hitInfo.point);
            }
        }
    }
}
