using UnityEngine;
using System.Collections;

public class ElectricShield : MonoBehaviour {

	void Start() {

		Physics2D.IgnoreLayerCollision (9, 8, true); //turns off ship damage from blocks

	}

	void OnCollisionEnter2D(Collision2D col){

		print ("here"); 

		if(col.gameObject.tag == "Block"){

			Block bl = col.gameObject.GetComponent<Block> ();
			bl.Damage (10);

		}

	}

	void OnDestroy() {

		Physics2D.IgnoreLayerCollision (9, 8, false); //turns on ship damage from blocks
		GM.shipOn = false;

	}
}
