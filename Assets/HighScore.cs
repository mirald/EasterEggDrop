using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	static public int score = 1000;

	void Awake(){
		if(PlayerPrefs.HasKey("EasterEggDropHighScore")){
			score = PlayerPrefs.GetInt("EasterEggDropHighScore");
		}

		PlayerPrefs.SetInt("EasterEggDropHighScore", score);
	}
	
	// Update is called once per frame
	void Update () {
		Text gt = this.GetComponent<Text>();
		gt.text = "High Score: " + score;

		if(score>PlayerPrefs.GetInt("EasterEggDropHighScore")){
			PlayerPrefs.SetInt("EasterEggDropHighScore", score);
		}
	}
}
