using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {
	
	public float DistanceAwayX = 5;
    public float DistanceAwayY = 5;
    public float DistanceAwayZ = 5;

    public Player player;
    public MainCamera mainCamera;
    public Vector3 PlayerPOS;
	// Use this for initialization
	void Start () {
        
        mainCamera = gameObject.GetComponent<MainCamera>();
        player = GameObject.Find("$Player").GetComponent<Player>();
        
	}
	
	// Update is called once per frame
	void Update () {
	position();
	}
	
	void position()
	{

        PlayerPOS = player.transform.position;
		mainCamera.transform.position = new Vector3(PlayerPOS.x - DistanceAwayX, PlayerPOS.y+  DistanceAwayY, PlayerPOS.z - DistanceAwayZ);
        mainCamera.transform.LookAt(player.transform);
	}
}
