using UnityEngine;
using System.Collections;

public class Plasma : MonoBehaviour {

	float moveSpeed;

	// Use this for initialization
	void Start () {
	
		moveSpeed = 75f;

	}

	void FixedUpdate() {

		Vector3 pos = transform.position;
		pos.x += moveSpeed * Time.deltaTime;
		transform.position = pos;

		if (transform.position.x > 60)
			Destroy (gameObject);

	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "Block"){

			Block bl = col.gameObject.GetComponent<Block> ();
			bl.DeleteBlock ();

		}

	}
}
