using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Animator anim;
	private float speed;
	private float cast;

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
		if (Input.GetKey ("1") || Input.GetKey ("2") || Input.GetKey ("3")) {
			cast = 0.2f;
			anim.SetFloat ("Cast", cast);
		} 
		else {
			cast = 0.0f;
			anim.SetFloat ("Cast", cast);
		}
	
    }
}