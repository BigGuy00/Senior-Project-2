using UnityEngine;
using System.Collections;

public class changeScene : MonoBehaviour {
	
	public void changeToScene (int sceneToChangeTo) {
		Application.LoadLevel (sceneToChangeTo);	
	}
}
