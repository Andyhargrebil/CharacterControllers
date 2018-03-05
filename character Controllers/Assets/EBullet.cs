using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour {

  public float speed = 5.0f;
  public AudioClip boom;

  // Use this for initialization
  void Start () {
    
  }
	
	// Update is called once per frame
	void Update () {
    transform.position += transform.forward * speed * Time.deltaTime;
  }

  void OnCollisionEnter(Collision hits)
  {
    Destroy (gameObject);
    if (hits.gameObject.tag == "Player")
    {
      GameObject.Find("Ghost").GetComponent<FirstPersonControls>().health--;
      AudioSource.PlayClipAtPoint(boom, transform.position);
    }
  }
}
