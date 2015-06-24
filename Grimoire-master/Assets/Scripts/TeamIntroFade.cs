using UnityEngine;
using System.Collections;

public class TeamIntroFade : MonoBehaviour {

	public float timer;

	void Update ()
	{
		timer -= Time.deltaTime;
		Debug.Log("Progress");

		if (timer <= 0) 
		{
			float FadingTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
			do
			{
				FadingTime -= Time.deltaTime;
			} while (FadingTime >= 0);
			Application.LoadLevel (1);
		}
	}

}
