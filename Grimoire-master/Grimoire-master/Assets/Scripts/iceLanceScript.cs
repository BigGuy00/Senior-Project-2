using UnityEngine;
using System.Collections;

public class iceLanceScript : MonoBehaviour {
    public Vector3 startPosition;
    public float maxDistance = 5;
    public int charges = 3;
    public int damage;

    void Awake()
    {
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

    
}