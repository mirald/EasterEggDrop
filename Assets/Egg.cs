using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour {

	public static float		bottomY = -20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < bottomY){
			Destroy(this.gameObject);
			// EasterEggDrop eggScript = Camera.main.GetComponent<EasterEggDrop>();

			// eggScript.EggDestroyed();
		}
		
	}
}
