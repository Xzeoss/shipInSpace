using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	float moveSpeed = 50f;
	[SerializeField]
	float health;
	public char label;
	float pph = 10f;
	[SerializeField]
	GameObject[] upgrades;
	GameObject electricShield;
	GameObject ship;

	//keeps the block at the same
	void FixedUpdate(){

		Vector3 pos = transform.position;
		pos.x -= (moveSpeed * Time.deltaTime);
		transform.position = pos;

	}

	//handles block damage taken
	public void Damage(float damage){

		health -= damage;
		if (health < 1) {

			DeleteBlock ();

		}
	}

	//handles logic for block destroy
	public void DeleteBlock(){

		switch(label){

		case 'A':	//ammoBlock destroy
			break;
		case 'B':	//blueBlock destroy
			GM.updateScore (20);
			break;
		case 'C':	//colourBlock destroy
			break;
		case 'E':	//electricShield destroy
			upgradeBlock();
			break;
		case 'G':	//greenBlock destroy
			GM.updateScore (10);
			break;
		case 'H':	//healthBlock destroy
			GM.updateHealth (30);
			break;
		case 'M':	//multiRow destroy
			break;
		case 'O':	//orangeBlock destroy
			GM.updateScore (40);
			break;
		case 'P':	//pointsBlock destroy
			GM.updateScore (50);
			break;
		case 'R':	//redBlock destroy
			GM.updateScore (50);
			break;
		case 'Y':	//yellowBlock destroy
			GM.updateScore (30);
			break;
		default:	//unlabelled block
			break;
		}

		Destroy (gameObject);

	}

	void upgradeBlock(){

		if (label == 'E' && !GM.shipOn) {
			ship = GameObject.Find ("Ship");
			GameObject go = (GameObject) Instantiate (upgrades [0], ship.transform.position, ship.transform.rotation);
			go.transform.parent = ship.transform;
			GM.shipOn = true;
			Destroy (go, 5f);
		} 
	}
		
}
