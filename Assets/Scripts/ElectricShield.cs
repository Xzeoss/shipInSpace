using UnityEngine;
using System.Collections;

public class ElectricShield : MonoBehaviour {

	void Start() {

		Physics2D.IgnoreLayerCollision (9, 8, true); //turns off ship damage from blocks
		Vector3 scale = transform.localScale;
		scale.x = 1.25f;
		scale.y = 1.25f;
		transform.localScale = scale;

	}

	void OnCollisionEnter2D(Collision2D col){

		if(col.gameObject.tag == "Block"){

			Asteroid ast = col.gameObject.GetComponent<Asteroid> ();
			ast.Damage (10);

		}

	}

	void OnDestroy() {

		Physics2D.IgnoreLayerCollision (9, 8, false); //turns on ship damage from blocks
		GM.shipOn = false;

	}
}
