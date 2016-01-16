using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{

    [SerializeField]
    Transform lazer;
	[SerializeField]
	Transform healthBar;
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
        {

            transform.position = new Vector3(transform.position.x, transform.position.y + 8, 0);

        }

        //moves ship down 8 pixels, or "1 row"

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && (transform.position.y > -15))
        {

            transform.position = new Vector3(transform.position.x, transform.position.y - 8, 0);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Shoot();

        }

    }

    void Shoot(){

        if (top)
        { //fire top gun

            lazerPos = new Vector3(transform.position.x - 2.2f, transform.position.y + 0.6f, transform.position.z);
            top = false;

        }
        else
        {

            lazerPos = new Vector3(transform.position.x - 2.2f, transform.position.y - 0.6f, transform.position.z);
            top = true;

        }

        Instantiate(lazer, lazerPos, transform.rotation);

    }

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Block") {

			GM.updateHealth (-10);

			//dec health; update bar; check if health == 0, reset health to maxhealth, reset healthbar
			
//			GM.health -= 10;
//			healthBar.transform.localScale = new Vector3 ((float)GM.health / GM.MAXHEALTH, 1, 1);
//			if (GM.health < 1) {
//				
//				GM.lives -= 1;
//				GM.health = GM.MAXHEALTH;
//				healthBar.transform.localScale = new Vector3 (1, 1, 1);
//
//			}

//			if(GM.lives < 1){
//
//				Debug.Log("Game Over!");
//				GM.lives = 3;
//
//			}

        }

    }
}
