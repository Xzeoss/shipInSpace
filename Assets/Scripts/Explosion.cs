using UnityEngine;
using System.Collections;

public class Explosion: MonoBehaviour {

	[SerializeField]
	GameObject explPart;

	void Start(){

		//spawns explosion particle system and destroys it 1 sec later
		Destroy (Instantiate (explPart, transform.position, transform.rotation), 1f);

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Block") {

			Block bl = col.gameObject.GetComponent<Block> ();
			bl.DeleteBlock ();	//calls deleteBlock logic for each block destroyed

		}

	}
}
