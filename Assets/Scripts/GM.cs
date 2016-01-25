using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour {

	int waveAmt;	//sets the amount of asteroids generated per wave
	int lastYPos;	//used to ensure asteroids are not spawned in repeated rows
	static float score;	//keeps the totalscore throughout game
	static float scaleX;
    public static int lives; 
	public static int health;	
	public static int MAXHEALTH = 500;
	public static bool shipOn;
	static Text scoreText; 
    static Text livesText; 
	static Transform healthBar;
	GameObject[] blockArr;
	GameObject curBlock;
	[SerializeField]
	GameObject[] asteroid;

	// Use this for initialization
	void Start(){

		score = 0;
        lives = 3;
		health = MAXHEALTH;
		healthBar = GameObject.Find ("HealthBar").transform;
		scaleX = healthBar.transform.localScale.x; //takes full size of healthbar
		scoreText = GameObject.Find ("Score").GetComponent<Text>();
		livesText = GameObject.Find ("Lives").GetComponent<Text> ();
		shipOn = false;
		Physics2D.IgnoreLayerCollision (9, 10, true); //ignores collisions between player/player effects
		Physics2D.IgnoreLayerCollision (10, 10, true); //ignores collisions between player effects 
		updateScore (0);
		InvokeRepeating ("spawnAsteroid", 0, 0.3f);
		waveAmt = 50;

	}

	void spawnAsteroid(){

		int yPos = Random.Range((int) 0, (int) 5) - 2;
		float asteroidRand = Random.Range (0.0f, 1.0f);
		while (yPos == lastYPos)
			yPos = Random.Range ((int)0, (int)5) - 2;
		if (asteroidRand > .95)
			Instantiate (asteroid [1], new Vector3 (40, yPos * 8, 0), Quaternion.identity);
		else if (asteroidRand > .85)
			Instantiate (asteroid [2], new Vector3 (40, yPos * 8, 0), Quaternion.identity); 
		else 
			Instantiate (asteroid[0], new Vector3(40, yPos * 8, 0), Quaternion.identity);
		lastYPos = yPos;
		if (waveAmt == 0)
			CancelInvoke ("spawnAsteroid");
		waveAmt--;

	}

	//deletes current grid of blocks
	void deleteArr(GameObject[] arr){

		for(int i = 0; i < arr.Length; i++){

			Destroy (arr[i]);

		}

	}

	//updates health value/sprite
	public static void updateHealth(int change){

		health += change; //updates health value based on change in (+/-)
		if(health > MAXHEALTH) //controls health max/min before resize
			health = MAXHEALTH;
		if (health < 0){
			updateLives (1); //removes a life
			health = MAXHEALTH;	//resets health
		}

		healthBar.localScale = new Vector3((float)health / MAXHEALTH * scaleX, 1, 1); //changes healthBar size

	}

	//updates lives, works opposite to others, give pos to decrease, neg to inc
	static void updateLives(int change){

		lives -= change;
		if (lives < 1) //handles "game over" logic
			lives = 0;

		livesText.text = lives.ToString ();


	}

	//updates score value/text
	public static void updateScore(float change){

		score += change;
		if (score < 0)
			score = 0;

		scoreText.text = score.ToString ();

	}
		
}
