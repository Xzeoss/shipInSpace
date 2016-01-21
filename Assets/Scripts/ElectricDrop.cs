using UnityEngine;
using System.Collections;

public class ElectricDrop : MonoBehaviour {

	float moveSpeed;
	public GameObject electricShield;

	// Use this for initialization
	void Start () {
	
		moveSpeed = 50f;
		Vector3 scale = transform.localScale;
		scale.x = 0.5f;
		scale.y = 0.5f;
		transform.localScale = scale;

	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = transform.position;
		pos.x -= moveSpeed * Time.deltaTime;
		transform.position = pos;

		if(pos.x < -60){

			Destroy (gameObject);

		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if(col.gameObject.tag == "Player"){

			if (!GM.shipOn) {
				GameObject go = (GameObject)Instantiate (electricShield, col.gameObject.transform.position, col.gameObject.transform.rotation);
				go.transform.parent = col.gameObject.transform;
				GM.shipOn = true;
				Destroy (go, 5f);
				Destroy (gameObject);
			}

		}

	}
}
