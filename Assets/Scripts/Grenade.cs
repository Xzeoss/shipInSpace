using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	GameObject ship;
	float moveSpeed;
	float rotSpeed;
	GameObject colObj;
	[SerializeField]
	GameObject explosion;

	// Use this for initialization
	void Start () {

		rotSpeed = 5;
		moveSpeed = 50;

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		pos.x += moveSpeed * Time.deltaTime;
		transform.position = pos;

		transform.Rotate (Vector3.back * rotSpeed);

		if (pos.x > 60)
			Destroy (gameObject);
	
	}

	void OnCollisionEnter2D(Collision2D col){

		colObj = col.gameObject;

		if(colObj.tag == "Block"){
			
			explosion = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);
			Destroy (explosion, 0.05f);

		}

	}
}
