using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{

    [SerializeField]
    Transform lazer;
	[SerializeField]
	Transform grenade;
	[SerializeField]
	Transform columnLaser;
	[SerializeField]
	Transform[] plasmaLaser;
    Vector3 lazerPos;
    bool top;

    // Use this for initialization

    void Start()
    {

        top = true;

    }

    // Update is called once per frame

    void Update(){

        //moves ship up 8 pixels, or "1 row"
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && (transform.position.y < 15))
            transform.position = new Vector3(transform.position.x, transform.position.y + 8, 0);
        //moves ship down 8 pixels, or "1 row"
		if ((Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) && (transform.position.y > -15))
			transform.position = new Vector3 (transform.position.x, transform.position.y - 8, 0);
        if (Input.GetKeyDown(KeyCode.Space))	//shoots laser
            shootLaser();
		if (Input.GetKeyDown (KeyCode.G))	//shoots grenade (destroy 3x3 grid)
			shootGrenade ();
		if (Input.GetKeyDown (KeyCode.C))	//shoots column laser (destroys 1st column it hits)
			shootColumn ();
		if (Input.GetKeyDown (KeyCode.P))	//shoots plasma laser (destroy on block in path)
			shootPlasma ();

    }

    void shootLaser(){

        if (top)
        { //fire top gun

            lazerPos = new Vector3(transform.position.x - 2.2f, transform.position.y + 0.6f, transform.position.z);
            top = false;

        }
        else //fire bottom gun
        {

            lazerPos = new Vector3(transform.position.x - 2.2f, transform.position.y - 0.6f, transform.position.z);
            top = true;

        }

        Instantiate(lazer, lazerPos, transform.rotation);

    }

	//spawns two plasma lasers
	void shootPlasma(){

		Vector3 plPos1 = new Vector3 (transform.position.x - 2.2f, transform.position.y + 0.6f, transform.position.z);
		Vector3 plPos2 = new Vector3 (transform.position.x - 2.2f, transform.position.y - 0.6f, transform.position.z);

		Instantiate (plasmaLaser [0], plPos1, transform.rotation);
		Instantiate (plasmaLaser [1], plPos2, transform.rotation);

	}

	//spawns grenade weapon
	void shootGrenade(){

		Instantiate(grenade, transform.position, transform.rotation); 

	}

	//spawns column laser weapon
	void shootColumn(){

		Instantiate (columnLaser, transform.position, transform.rotation);

	}
		
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Block") {

			GM.updateHealth (-10);	//ship takes damage

        }

    }
}
