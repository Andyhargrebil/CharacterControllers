using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControls : MonoBehaviour
{
  public float rotationSpeed = 360f; // Degrees per second
  public float speed = 4.0f;
  public float motionScale = 10f;
  public float maxArc = 30f;
  public int health = 5;

  public Transform eyes;
  public Transform player;
  public Transform anchor;
  public GameObject ammo;
  public GameObject goal;

  public GameObject[] needtoshoot;

  public bool canMove = true;

  // Use this for initialization
  void Start()
  {
    new Vector3(1, 1, 1);

    goal.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 moveDirection = Vector3.zero;

    needtoshoot = GameObject.FindGameObjectsWithTag("NeedtoDestroy");

    GameObject.Find("Propellor A").GetComponent<BasicRotate>().rotationSpeed = 360;
    GameObject.Find("Propellor B").GetComponent<BasicRotate>().rotationSpeed = 360;

    float mouseX = Input.GetAxis("Mouse X");
    float mouseY = Input.GetAxis("Mouse Y");
    float mouseW = Input.GetAxis("Mouse ScrollWheel");

    if (Input.GetKey(KeyCode.W) && canMove == true)
    {
      moveDirection += transform.forward;
      GameObject.Find("Propellor A").GetComponent<BasicRotate>().rotationSpeed = 540;
      GameObject.Find("Propellor B").GetComponent<BasicRotate>().rotationSpeed = 540;
    }

    if (Input.GetKey(KeyCode.S) && canMove == true)
    {
      moveDirection += -transform.forward;
      GameObject.Find("Propellor A").GetComponent<BasicRotate>().rotationSpeed = 180;
      GameObject.Find("Propellor B").GetComponent<BasicRotate>().rotationSpeed = 180;
    }

    if (Input.GetKey(KeyCode.A) && canMove == true)
    {
      moveDirection += -transform.right;
    }

    if (Input.GetKey(KeyCode.D) && canMove == true)
    {
      moveDirection += transform.right;
    }

    moveDirection.y = 0;

    if (mouseX > 0 && canMove == true)
    {
      anchor.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
      player.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
    if (mouseX < 0 && canMove == true)
    {
      anchor.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
      player.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
    }

    float adjustedEuler = eyes.eulerAngles.x;
    if (adjustedEuler > 180)
    {
      adjustedEuler -= 360;
    }

    if (mouseY > 0 && adjustedEuler > 5 && canMove == true)
    {
      anchor.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
    }
    if (mouseY < 0 && adjustedEuler < 65 && canMove == true)
    {
      anchor.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }

    if (mouseW > 0 && canMove == true)
    {
      eyes.position += eyes.forward;
    }

    if (mouseW < 0 && canMove == true)
    {
      eyes.position -= eyes.forward;
    }

    if (Input.GetMouseButtonDown(0) && canMove == true)
    {
      Instantiate(ammo, player.position, player.rotation);
    }

    if (needtoshoot.Length == 0)
    {
      goal.SetActive(true);
    }

    if (health <= 0)
    {
      GameObject.Find("Propellor A").GetComponent<BasicRotate>().rotationSpeed = 0;
      GameObject.Find("Propellor B").GetComponent<BasicRotate>().rotationSpeed = 0;
      canMove = false;
    }

    player.position += moveDirection.normalized * speed * Time.deltaTime;
    transform.position = player.position;
  }

  void OnTriggerEnter(Collider player)
  {
    canMove = false;
  }
}
