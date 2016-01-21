using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public GameObject upgradeDrop;
	float moveSpeed;
	float health;
	float pph;
	float rotSpeed;
	public char label;

	// Use this for initialization
	void Start () {
	
		moveSpeed = 50;
		rotSpeed = Random.Range(2f, 5f);
		health = Random.Range((int) 1, (int) 6) * 10; //give random range 10 - 30
		pph = 10;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		Vector3 pos = transform.position;
		pos.x -= moveSpeed * Time.deltaTime;
		transform.position = pos;

		transform.Rotate (Vector3.forward * rotSpeed);

		if(transform.position.x < -60){

			Destroy (gameObject);

		}

	}

	//handles block damage taken
	public void Damage(float damage){

		health -= damage;
		GM.updateScore (pph);
		if (health < 1) {

			switch(label){

			case 'E':
				electricDrop ();
				break;
			case 'H':
				healthDrop ();
				break;
			case 'N':
				break;
			default:
				break;

			}

			Destroy (gameObject);

		}
	}

	public void DeleteBlock(){

		Destroy (gameObject);

	}

	void electricDrop(){

		Instantiate (upgradeDrop, transform.position, transform.rotation);

	}

	void healthDrop(){

		GM.updateHealth (10);

	}
}
