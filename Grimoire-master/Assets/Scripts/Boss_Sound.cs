using UnityEngine;
using System.Collections;

public class Boss_Sound : MonoBehaviour {
	
	void Start () {
		

		var go = GameObject.Find ("GameMusic");

		go = GameObject.Find ("GameMusic");

		
		if (go) {
			Destroy(go);
		}
		
		DontDestroyOnLoad (gameObject);
	}
}
