using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterBunny : MonoBehaviour {

	public GameObject eggPrefab;
	public GameObject goldenEggPrefab;
	public GameObject deathEggPrefab;
	public GameObject healthPrefab;

	public float speed = 18f;
	public float leftAndRightEdge = 25f;
	public float chanceToChangeDirections = 0.01f;
	public float secondsBetweenEggDrops = 1f;
	private int count = 3;
	public Text	counterGT;

	int pointThreshold = 100;
	float maxRange = 4f;
	float minRange = 2f;
	float ranTime;
	// float mediumRandomTime;
	// float longerRandomTime;

	// public float RandomNum(float max){
	// 	Random r = new Random();
	// 	double range = (double) max;
	// 	float random = (float) r.NextDouble()* range;
	// 	return random;
	// }  

	void Start() {
		// dropping apples every second
		InvokeRepeating("startCounter", .1f , 1f);

		InvokeRepeating("moreSpeed", 5f, 5f);
	}

	float random(float min, float max){
		return Random.Range(min, max);
	}

	void DropEgg(){
		if(!GameOver.done){
			GameObject egg = Instantiate(eggPrefab) as GameObject;
			egg.transform.position = transform.position;

			Invoke("DropEgg", random(0f, secondsBetweenEggDrops));
		}
	}

	void DropHealth(){
		if(!GameOver.done){
			GameObject health = Instantiate(healthPrefab) as GameObject;
			health.transform.position = transform.position;

			Invoke("DropHealth", random(30f, 60f));
		}
	}

	void DropGoldenEgg(){
		if(!GameOver.done){
			GameObject goldenEgg = Instantiate(goldenEggPrefab) as GameObject;
			goldenEgg.transform.position = transform.position;

			Invoke("DropGoldenEgg", random(20f, 60f));
		}
	}

	void DropDeathEgg(){
		if(!GameOver.done){

			int currentScore = Basket.score;

			if(pointThreshold > currentScore ){
				ranTime = random(minRange, maxRange);
			}else {
				pointThreshold = pointThreshold*2;

				if(minRange>0.1f)
					minRange = minRange - 0.1f;
				if(maxRange>0.4)
					maxRange = maxRange - 0.2f;

				ranTime = random(minRange, maxRange);
			}

			GameObject deathEgg = Instantiate(deathEggPrefab) as GameObject;
			deathEgg.transform.position = transform.position;

			Invoke("DropDeathEgg", ranTime);
		}
	}

	void Update() {
		// Basic movement
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;

		// Changing direction

		if (pos.x < -leftAndRightEdge){
			speed = Mathf.Abs(speed);
		} else if(pos.x > leftAndRightEdge){
			speed = -Mathf.Abs(speed);
		}
	}

	void FixedUpdate(){
		if (Random.value < chanceToChangeDirections){
			speed *= -1;
		}
	}

	void moreSpeed(){
		if(!GameOver.done){
			speed = Mathf.Abs(speed) + 0.2f;
		}
	}

	void startCounter(){	
		
		GameObject counterGO = GameObject.Find("startCounter");

		if(count==0){
			Destroy(counterGO);

			Invoke("DropEgg", .5f);
			Invoke("DropGoldenEgg", 20f);
			Invoke("DropDeathEgg",30f);
			Invoke("DropHealth", 60f);

			CancelInvoke("startCounter");
		}else{
			counterGT = counterGO.GetComponent<Text>();
			counterGT.text = count.ToString();

			count--;
		}
	}
}
