using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public int health;
    public float speed;
    public int state;
    public Vector3 targetPosition;
    public float minDistanceAttack;
    public Vector3 origin;
    public bool inCombat;
    public float detectionDistance;
    public GameObject target;

    public RaycastHit hit;
    public iceLanceScript iceLance;
   
    public Vector3 leftForwardRay;
    public Vector3 rightForwardRay;
    public float aggroDistance = 10.0f;
    public bool atLocation;
    public float walkSpeed = 5.0f;
    public float runSpeed = 10.0f;
    public Vector3 direction;
    public Vector3 currentPosition;
    public float idleLength = 5;
    public float timeStamp;
    public float attackRange = 1.5f;
    public float attackSpeed = 10.0f;
    public float attackCooldown = 1.0f;
    public bool canAttack = true;
    public PlayerScript player;
    public float attackTimeStamp;
    public float distanceFromTarget;
    public Vector3 vertOffset = new Vector3(0, .4f, 0);

	public int AttackDamage; 

   

    // Use this for initialization
    void Start()
    {
        origin = transform.position;
        rightForwardRay = new Vector3(Mathf.Cos(210), 0f, Mathf.Sin(210));
        leftForwardRay = new Vector3(-Mathf.Cos(210), 0f, Mathf.Sin(210));
        atLocation = true;
        player = GameObject.Find("$Player").GetComponent<PlayerScript>();
        health = 5;

        canAttack = true;

		canAttack = true;

    }

    // Update is called once per frame
    void Update()
    {
        enemyState();
        if (health <= 0)
        {
            state = 6;           
        }
        if(!canAttack)
        {
            if(attackTimeStamp+ attackCooldown <Time.time)
            {
                canAttack = true;
            }
        }
        //OnDrawGizmos();
    }

    void enemyState()
    {
        switch (state)
        {
            case 0:
                {
                    idle();
                    break;
                }
            case 1:
                {                 
                    break;
                }
            case 2:
                {
                    chase();
                    break;
                }
            case 3:
                {
                    attack();
                    break;
                }
            case 6:
                {
                    destroyed();
                    break;
                }
        }
    }

    void idle()
    {
        detectTarget();
    }

    /*void wander()
    {
        detectTarget();
        if (atLocation)
        {
            currentPosition = transform.position;
            targetPosition = new Vector3(currentPosition.x + Random.Range(-5, 5), (currentPosition.y), (currentPosition.z + Random.Range(-5, 5)));
            move(targetPosition);
            atLocation = false;
        }
        else
        {
            move(targetPosition);
        }
    }*/

    void chase()
    {
        detectTarget();
        if (target != null)
        {            
            distanceFromTarget = Vector3.Distance(transform.position, target.transform.position);
            if(distanceFromTarget > attackRange)
            {
                transform.LookAt(target.transform);
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .01f);
            }          
            if (distanceFromTarget < attackRange)
            {              
                
                Vector3 pushBackPos = (this.transform.position - targetPosition);
                Vector3 newPos = (targetPosition + pushBackPos);                    
                attack();
            }
        }
        else
        {
            state = 0;
        }
    }

    void attack()
    {
        if (canAttack)
        {
            //Attack player based off animation
            attackTimeStamp = Time.time;
            canAttack = false;
        }
        else
        {

        }
    }

    

    void destroyed()
    {
        Destroy(gameObject);

    }

    void detectTarget()
    {
        
        if (Physics.Raycast(transform.position+ vertOffset, Vector3.forward + vertOffset, out hit, aggroDistance))
        {
            
            if (hit.collider.tag == "Player" )
            {
                
                target = hit.collider.gameObject;
                state = 2;
            }
        }
        if (Physics.Raycast(transform.position + vertOffset, leftForwardRay + vertOffset, out hit, aggroDistance))
        {
            if (hit.collider.tag == "Player")
            {
                target = hit.collider.gameObject;
                state = 2;
            }
        }
        if (Physics.Raycast(transform.position + vertOffset, rightForwardRay + vertOffset, out hit, aggroDistance))
        {
            if (hit.collider.tag == "Player")
            {
                target = hit.collider.gameObject;
                state = 2;
            }
        }
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 15.0f)
            {
                target = null;

            }
        }
    }

    void move(Vector3 targetPosition)
    {
        if (target == null)
        {
            transform.LookAt(targetPosition);
            transform.position += (targetPosition - transform.position).normalized * walkSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, targetPosition) < 1.0f)
            {
                atLocation = true;
                timeStamp = Time.time;
                state = 0;
            }
        }
        else
        {
            state = 2;
        }
    }

    void OnDrawGizmos()
    {
       
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {      

          
            //Damage Player
           


            //Damage Player
			col.gameObject.SendMessage("Hit", AttackDamage);  


        }  
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.name == "iceLance(Clone)")
        {
            iceLance = col.GetComponent<iceLanceScript>();
            iceLance.charges--;
        }
    }

    void Hit(int dmg)
    {
        health -= dmg;
    }

}



