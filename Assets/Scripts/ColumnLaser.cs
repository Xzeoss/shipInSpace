using UnityEngine;
using System.Collections;

public class ColumnLaser : MonoBehaviour {

	float yScale;
	float xScale;
	float rotSpeed;
	float moveSpeed;
	bool collided;

	void Start(){

		yScale = 175;
		xScale = 20;
		rotSpeed = 5;
		moveSpeed = 50;
		collided = false;

	}

	// Update is called once per frame
	void FixedUpdate () {
	
		if (!collided) {

			Vector3 pos = transform.position;
			pos.x += moveSpeed * Time.deltaTime;
			transform.position = pos;

			transform.Rotate (Vector3.back * rotSpeed);

		} else {

			GetComponent<CircleCollider2D>().enabled = false;
			GetComponent<EdgeCollider2D> ().enabled = true;

			transform.rotation = Quaternion.identity;

			Vector3 scale = transform.localScale;
			if (scale.x > 0.1f)
				scale.x -= xScale * Time.deltaTime;
			if (scale.x < 0.1f)
				scale.x = 0.1f;
			if (scale.x < 0.5f) {
				if (scale.y < 16f)
					scale.y += yScale * Time.deltaTime;
				if (scale.y > 16f)
					scale.y = 16f;
			}
			
			transform.localScale = scale;

		}

	}

	void OnCollisionEnter2D(Collision2D col){

		collided = true;

		if(col.gameObject.tag == "Block"){

			Block bl = col.gameObject.GetComponent<Block> ();
			bl.DeleteBlock ();

		}
		Destroy (gameObject, 0.1f); 

	}
}
