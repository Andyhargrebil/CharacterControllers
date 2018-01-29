using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControls : MonoBehaviour
{
    public float rotationSpeed = 360f; // Degrees per second
    public float speed = 4.0f;
    public float motionScale = 10f;
    public float maxArc = 30f;

    public Transform eyes;
    // Use this for initialization
    void Start()
    {
        new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        if (mouseX > 0)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (mouseX < 0)
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        float adjustedEuler = eyes.eulerAngles.x;
        if (adjustedEuler > 180)
        {
            adjustedEuler -= 360;
        }

        if (mouseY > 0 && adjustedEuler > -maxArc)
        {
            eyes.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);      
        }
        if (mouseY < 0 && adjustedEuler < maxArc)
        {
            eyes.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);           
        }

    transform.position += moveDirection.normalized* speed * Time.deltaTime;
    }
}
