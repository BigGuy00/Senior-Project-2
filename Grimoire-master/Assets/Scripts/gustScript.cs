using UnityEngine;
using System.Collections;

public class gustScript : MonoBehaviour {
    public Vector3 startPosition;
    public float maxDistance = 15;
    public int damage;

    void Awake()
    {
        maxDistance = 15;

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
    }

    void checkDistance()
    {

        if (Vector3.Distance(transform.position, startPosition) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.SendMessage("Hit", damage);

            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Map")
        {

            Destroy(gameObject);
        }





    }
}