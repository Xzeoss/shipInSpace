using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	Vector3 direction;
	Vector3 destination;
	float moveSpeed;
	public float damage;
	GameObject ship;
	GameObject colObj; //collided object

	// Use this for initialization
	void Start () {
		moveSpeed = 100f;
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 pos = transform.position;
		pos.x += moveSpeed * Time.deltaTime;
		transform.position = pos;

		if (transform.position.x > 60)
			GM.DeleteObject (gameObject);

	}

	void OnCollisionEnter2D(Collision2D col){

		colObj = col.gameObject;

		if(colObj.tag == "Block"){

			Block bl = colObj.GetComponent<Block> ();
			bl.Damage (damage);

		}

		GM.DeleteObject (gameObject);

	}

}
