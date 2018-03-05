using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{

    public LayerMask floorOnly;
    public Transform player;
    public GameObject ammo;
    public float cooldown = 0.0f;

    public bool debug = false;

    // Use this for initialization
    void Start()
    {

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
            }
        }
    }
}
