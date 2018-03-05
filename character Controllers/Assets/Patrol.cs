using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public float speed = 4.0f;
    public float cooldown = 0.0f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDirection = Vector3.zero;
        cooldown += 1;

        if(cooldown > 150)
        {
            cooldown = 0;
            transform.Rotate(Vector3.up, 90);
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
