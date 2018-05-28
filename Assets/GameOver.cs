using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject	gameOverPrefab;

	public Text			endScore;

	static public bool 		done = false;

	// Use this for initialization
	public void GameOverScreen () {
		GameObject gameOverGO = Instantiate(gameOverPrefab) as GameObject;

		done = true;

		GameObject scoreCountGO = GameObject.Find("scoreCount");

		endScore = scoreCountGO.GetComponent<Text>();
		endScore.text = Basket.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			done = false;
			Application.LoadLevel("_scene_0");
		}
	}
}
