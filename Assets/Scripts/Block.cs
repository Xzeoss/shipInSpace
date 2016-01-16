using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	float moveSpeed = 50f;
	[SerializeField]
	float health;
	public char label;
	float pph = 10f;

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

		case 'G':	//greenBlock destroy
			GM.updateScore (10);
			break;
		case 'B':	//blueBlock destroy
			GM.updateScore (20);
			break;
		case 'Y':	//yellowBlock destroy
			GM.updateScore (30);
			break;
		case 'O':	//orangeBlock destroy
			GM.updateScore (40);
			break;
		case 'R':	//redBlock destroy
			GM.updateScore (50);
			break;
		case 'H':	//healthBlock destroy
			GM.updateHealth (30);
			break;
		case 'P':	//pointsBlock destroy
			GM.updateScore (50);
			break;
		case 'U':	//upgradeBlock destroy
			break;
		case 'W':	//weaponBlock destroy
			break;
		default:	//unlabelled block
			break;
		}

		Destroy (gameObject);

	}
}
