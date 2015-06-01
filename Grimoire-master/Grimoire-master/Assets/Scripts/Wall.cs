using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
    public iceLanceScript iceLance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.name == "iceLance(Clone)")
        {
            iceLance = col.GetComponent<iceLanceScript>();
            Destroy(col.gameObject);



        }

    }
}
