using UnityEngine;
using System.Collections;

public class Background_Sound : MonoBehaviour {

	void Start () {

		GameObject go = GameObject.Find ("BossMusic");

		if (go) {
			Destroy(go);
		}

		DontDestroyOnLoad (gameObject);
	}
}
