using UnityEngine;
using System.Collections;

public class Explosion: MonoBehaviour {

	[SerializeField]
	GameObject explPart;

	void Start(){

		Destroy (Instantiate (explPart, transform.position, transform.rotation), 1f);

	}

	void OnCollisionEnter2D(Collision2D col){

		Destroy (col.gameObject);

	}
}
