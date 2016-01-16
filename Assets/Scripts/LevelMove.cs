using UnityEngine;
using System.Collections;

public class LevelMove : MonoBehaviour {

	private Vector3 direction;
	private Vector3 destination;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		destination = new Vector3 (-60, transform.position.y, transform.position.z);
		direction = destination - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.GetComponent<Rigidbody2D>().MovePosition( transform.position + direction * (moveSpeed / 5) * Time.fixedDeltaTime);
	}
}
