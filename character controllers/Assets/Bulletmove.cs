using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour {

	public float speed = 5.0f;

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
		if (hits.gameObject.tag == "NeedtoDestroy") {
			Destroy (hits.gameObject);
		}
	}
}
