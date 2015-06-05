using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {

	public int levelToGoTo;

	void OnTriggerStay(Collider other)
	{
		if(other.name == "NextLevel")
		{
			Application.LoadLevel (levelToGoTo);
		}
	}
}
