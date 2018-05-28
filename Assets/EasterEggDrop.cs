using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggDrop : MonoBehaviour {

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
	public List<GameObject> basketList;
	public static bool	firstTime;

	int basketCount;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject>();
		for (int i=0; i<numBaskets; i++){
			firstTime = true;
			GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);
			tBasketGO.transform.position = pos;
			basketList.Add(tBasketGO);
		}
	}

	public void RemoveBasket(){
		// GameObject[] tEggArray = GameObject.FindGameObjectsWithTag("deathegg");

		// foreach(GameObject tGO in tEggArray){
		// 	Destroy(tGO);
		// }

		
		int basketIndex = basketList.Count-1;

		if(basketIndex>=0){
			GameObject tBasketGO = basketList[basketIndex];

			basketList.RemoveAt(basketIndex);
			Destroy(tBasketGO);
		}
		

		if (basketList.Count == 0){
			GameOver gameOverScript = Camera.main.GetComponent<GameOver>();

			gameOverScript.GameOverScreen();
		}
	}

	public void AddBasket(){
		// GameObject[] tEggArray = GameObject.FindGameObjectsWithTag("health");

		// foreach(GameObject tGO in tEggArray){
		// 	Destroy(tGO);
		// }

		int basketCount = basketList.Count;

		if(basketCount<numBaskets){
			GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;

			GameObject[] tBasketPosArray = GameObject.FindGameObjectsWithTag("basket");

			Vector3 pos = tBasketPosArray[0].transform.position;
			pos.y = basketBottomY + (basketSpacingY * (basketCount));
			tBasketGO.transform.position = pos;

			basketList.Add(tBasketGO);
			firstTime = false;
		}
	}

	// public void GameOver(){
	// 	GameObject gameOverGO = Instantiate(gameOverPrefab) as GameObject;

	// 		GameObject scoreCountGO = GameObject.Find("scoreCount");

	// 		endScore = scoreCountGO.GetComponent<Text>();
	// 		endScore.text = Basket.score.ToString();
			
	// 		if(Input.GetKey(KeyCode.Escape)){
	// 			Application.LoadLevel("_scene_0");
	// 		}
	// }

}
