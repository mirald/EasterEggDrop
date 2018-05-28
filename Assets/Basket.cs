using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	public Text	scoreGT;

	public float speed = 30f;

	public static int score;

	int times = 0;

	void Start () {
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text>();
		if(EasterEggDrop.firstTime){
			scoreGT.text = "0";	
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-speed*Time.deltaTime, 0f, 0f);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(speed*Time.deltaTime, 0f, 0f);
	}

	void OnCollisionEnter(Collision coll){
		GameObject collideWith = coll.gameObject;

		score = int.Parse(scoreGT.text);

		string typeOfEgg = collideWith.tag;

		EasterEggDrop eggScript = Camera.main.GetComponent<EasterEggDrop>();

		switch (typeOfEgg){
			case "egg":
				score += 10;
				Destroy(collideWith);
				break;
			case "goldenegg":
				score += 250;
				Destroy(collideWith);
				break;
			case "deathegg":
				eggScript.RemoveBasket();
				Destroy(collideWith);
				break;
			case "health":
				eggScript.AddBasket();
				Destroy(collideWith);
				break;
		}

		// if (collideWith.tag == "egg"){
		// 	Destroy(collideWith);
			
		// } else if(collideWith.tag=="goldenegg"){
		// 	Destroy(collideWith);
		// 	score += 100;
		// }

		scoreGT.text = score.ToString();

		if(score>HighScore.score){
			HighScore.score = score;
		}
	}
}
