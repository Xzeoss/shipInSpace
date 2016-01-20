using UnityEngine;
using System.Collections;
using System;

public class Lazer : MonoBehaviour {

	float moveSpeed;
	public float damage;

	// Use this for initialization
	void Start () {
		moveSpeed = 100f;
	}

	// Update is called once per frame
	void FixedUpdate () {

		//horizontal movement
		Vector3 pos = transform.position;
		pos.x += moveSpeed * Time.deltaTime;
		transform.position = pos;

		if (transform.position.x > 60)	//destroys laser when off screen
			Destroy (gameObject);

	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "Block"){	//calls block method to handle block destroy

			try{

				Block bl = col.gameObject.GetComponent<Block> ();
				bl.Damage (damage);

			}catch(NullReferenceException e){

				Asteroid ast = col.gameObject.GetComponent<Asteroid> ();
				ast.Damage (damage);

			}

		}

		Destroy (gameObject);

	}

}
