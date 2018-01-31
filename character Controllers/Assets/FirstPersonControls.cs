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
    public Transform player;
    public Transform anchor;

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
        float mouseW = Input.GetAxis("Mouse ScrollWheel");

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

        moveDirection.y = 0;

        if (moveDirection != Vector3.zero)
        {
            player.forward = moveDirection;
        }

        if (mouseX > 0)
        {
            anchor.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
        if (mouseX < 0)
        {
            anchor.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
        }

        float adjustedEuler = eyes.eulerAngles.x;
        if (adjustedEuler > 180)
        {
            adjustedEuler -= 360;
        }

        if (mouseY > 0 && adjustedEuler > 5)
        {
            anchor.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
        }
        if (mouseY < 0 && adjustedEuler < 65)
        {
            anchor.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }

        if (mouseW > 0)
        {
            eyes.position += eyes.forward;
        }

        if (mouseW < 0)
        {
            eyes.position -= eyes.forward;
        }

        player.position += moveDirection.normalized* speed * Time.deltaTime;
        transform.position = player.position;
    }
}
