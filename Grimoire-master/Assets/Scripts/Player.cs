using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Animator anim;
	private float speed;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		speed = move.moveSpeed;
		if (speed > 0) {
			anim.SetFloat ("Walk", 1);
		}
		if (speed < 1) {
			anim.SetFloat ("Walk", 0);
		}
	}
}
