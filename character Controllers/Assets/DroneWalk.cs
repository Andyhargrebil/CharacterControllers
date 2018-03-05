using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneWalk : MonoBehaviour
{

    public LayerMask floorOnly;
    public Transform player;
    public GameObject ammo;
    public float speed = 4.0f;
    private Vector3 moveDirection;
    public bool foundYou;
    public float cooldown = 0.0f;

    // Use this for initialization
    void Start()
    {
        moveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += 1;
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, player.position - transform.position, out hitInfo, 1000f, floorOnly))
        {
            if (hitInfo.transform.gameObject.tag == "Player")
            {
                transform.forward = player.position - transform.position;
                if (cooldown > 60)
                {
                    Instantiate(ammo, transform.position, transform.rotation);
                    cooldown = 0;
                }
                foundYou = true;
                transform.forward = player.position - transform.position;
            } else { foundYou = false; }
        } else
        {
            foundYou = false;
        }

        if (foundYou == true)
        {
            moveDirection = player.position - transform.position;
            moveDirection.Normalize();
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }
}
