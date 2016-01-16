using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	private Vector3 direction;
	private Vector3 destination;
	public float moveSpeed;
	public float damage;
	GameObject ship;

	// Use this for initialization
	void Start () {
		ship = GameObject.Find ("Ship");
		Physics2D.IgnoreCollision(ship.GetComponent<Collider2D>(), GetComponent<Collider2D>());
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 pos = transform.position;
		pos.x += moveSpeed * Time.deltaTime;
		transform.position = pos;

		if (transform.position.x > 60) {
			
			GM.DeleteObject (gameObject);
		
		}

	}

}
