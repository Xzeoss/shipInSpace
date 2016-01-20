using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour {

	int gridSize;	//sets the amount of blocks generated per wave
	static float score;	//keeps the totalscore throughout game
    public static int lives; 
	public static int health;	
	public static int MAXHEALTH = 500;
	public static bool shipOn;
	static Text scoreText; 
    static Text livesText; 
	static Transform healthBar;
	[SerializeField]
	GameObject[] prefabArr;
	GameObject[] blockArr;
	GameObject curBlock;
	GameObject ship;
	[SerializeField]
	GameObject asteroid;

	// Use this for initialization
	void Start(){

		score = 0;
        lives = 3;
		health = MAXHEALTH;
		gridSize = 15;
		blockArr = new GameObject[gridSize];
		healthBar = GameObject.Find ("HealthBar").transform;
		scoreText = GameObject.Find ("Score").GetComponent<Text>();
		livesText = GameObject.Find ("Lives").GetComponent<Text> ();
		ship = GameObject.Find ("Ship");
		shipOn = false;
		Physics2D.IgnoreLayerCollision (9, 10, true); //ignores collisions between player/player effects
		Physics2D.IgnoreLayerCollision (10, 10, true); //ignores collisions between player effects 
		updateScore (0);
		spawnAsteroid ();

	}

	// Update is called once per frame
	void Update(){

		if((blockArr[gridSize - 1] != null) || (blockArr[2] != null)){ //object has been instantiated

			try { //check for bottom row instance

				if(blockArr [gridSize - 1].transform.position.x < -60){

					deleteArr (blockArr);
					//waveGenerator ();

				}

			}catch (MissingReferenceException e){ //player destroyed bot row, test top row

				if(blockArr[2].transform.position.x < -60){

					deleteArr (blockArr);
					//waveGenerator ();

				}

			}
				
		}

	}

	int lastYPos;

	void spawnAsteroid(){

		int yPos = Random.Range((int) 0, (int) 5) - 2;
		while (yPos == lastYPos)
			yPos = Random.Range ((int)0, (int)5) - 2;
		Instantiate (asteroid, new Vector3(60, yPos * 8, 0), Quaternion.identity);
		lastYPos = yPos;
		Invoke ("spawnAsteroid", 0.3f);

	}

	//generates random block wave
	void waveGenerator(){
		
		float[] randArr = genRandArr ();

		int posY = 16; //posY is row pos, posX is col
		int posX, k = 0; // k used to iterate through randArr

		for(int i = 0; i < 5; i++){

			posX = 60;

			for(int j = 0; j < 3; j++){

				curBlock = getBlock (randArr [k]);
				blockArr[k] = (GameObject)Instantiate (curBlock, new Vector3(posX, posY, 0), Quaternion.identity);
				k++;
				posX += 8; //moves over one column

			}

			posY -= 8; //moves down one row

		}
	}

	//returns a random array for each block spot in grid
	float[] genRandArr(){

		float[] arr = new float[gridSize]; 

		for(int i = 0; i < gridSize; i++){

			arr [i] = Random.value; //returns float from 0.0 - 1.0 [inclusive]

		}

		return arr;

	}

	//returns gameblock to instantiate
	GameObject getBlock(float rand){

		if (rand < 0.25f)
			return prefabArr [0]; //returns greenBlock (25%)
		else if (rand < 0.5f)
			return prefabArr [1]; //returns blueBlock (25%)
		else if (rand < 0.7f)
			return prefabArr [2]; //returns yellowBlock (20%)
		else if (rand < 0.85f)
			return prefabArr [3]; //returns orangeBlock (15%)
		else if (rand < 0.9f)
			return prefabArr [4]; //returns redBlock (5%)
		else if (rand < .925f)
			return prefabArr [5]; //returns healthBlock (2.5%)
		else if (rand < .95f)
			return prefabArr [6]; //returns pointsBlock (1.5%)
		else if (rand < .975f)
			return prefabArr [7]; //returns uelectricShieldBlock (1%)
		else
			return prefabArr [8]; //returns weaponBlock (1%)
		
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
			health = MAXHEALTH;
		}

		healthBar.localScale = new Vector3((float)health / MAXHEALTH * 12, 1, 1); //changes healthBar size

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

		scoreText.text = "Score " + score;

	}
		
}
