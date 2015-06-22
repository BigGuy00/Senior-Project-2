using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public iceLanceScript iceLance;
    public float health;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "iceLance(Clone)")
        {
            iceLance = col.GetComponent<iceLanceScript>();
            iceLance.charges--;



        }

    }
}
