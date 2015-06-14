using UnityEngine;
using System.Collections;

public class iceLanceScript : MonoBehaviour {
    public Vector3 startPosition;
    public float maxDistance = 5;
    public int charges = 3;
    public int damage;
    public Spells spells;
    void Awake()
    {
        spells = GameObject.Find("$Player").GetComponent<Spells>();
        damage = spells.iceLanceDamage;
        maxDistance = 5;

    }
    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        checkDistance();
        if(charges <=0)
        {
            Destroy(gameObject);

        }
    }

    void checkDistance()
    {

        if (Vector3.Distance(transform.position, startPosition) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("here");
            col.gameObject.SendMessage("Hit", damage);

            charges--;
        }
        if (col.gameObject.tag == "Map")
        {
            charges--;
        }





    }
    
}