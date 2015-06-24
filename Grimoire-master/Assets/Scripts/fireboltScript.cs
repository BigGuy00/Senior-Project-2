using UnityEngine;
using System.Collections;

public class fireboltScript : MonoBehaviour {
    public Vector3 startPosition;
    public float maxDistance=10;
    public int damage;
    public Spells spells;
    void Awake()
    {
        spells = GameObject.Find("$Player").GetComponent<Spells>();
        damage = spells.fireboltDamage;
        maxDistance = 10;

    }
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        checkDistance();
	}

    void checkDistance()
    {
        
        if(Vector3.Distance(transform.position, startPosition) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {

            col.gameObject.SendMessage("Hit", damage);

			col.gameObject.SendMessage("Hit", damage);

            
            Destroy(gameObject);
        } 
        if(col.gameObject.tag == "Map")
        {

            Destroy(gameObject);
        }
       

       


    }
}
