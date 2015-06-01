using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Spells : MonoBehaviour {
    /*Firebolt: Simple fire magic that all fledgeling mages are first taught. The range on the
bolt is medium range so it safe to cast without having to be up close and personal with 
your enemy. The spells resembles what a crossbolt would look like if it was completely 
set ablaze. When cast it is shot in a straight to a single target, if there is anything that is 
in the way, then that is was the bolt will hit first. Mana Cost: 15 MP, Cast Time: Instant, 
Cooldown Time: One Round. Distance: 30 yards, Damage: 11 Fire Based Damage.

● Ice Lance: A second ranked ice spell that has a short range than the firebolt but is more 
dense so it will travel through several objects before breaking. In the shape of a lance, 
this spell must be cast closer to the opponent, but has a better damage output and will 
go through the first 3 enemies before its magic is spent. Mana Cost: 25 MP, Cast Time: 
Instant, Cooldown Time: Two Rounds. Distance: 20 yards, Damage: 14 Ice Based 
Damage per person hit.

● Rock Armor: The first type of defensive spell that coats the user in a hard earthy shell, it 
is able to mitigate a certain amount of damage before its magic is spent. Mana Cost: 
40MP, Cast Time: One Round, Cooldown Time: Four Rounds, Target: Self,  Ability: User 
takes 15% less damage per hit and lasts for four rounds.

● Gust: Wind that manifests into blades that cut your opponent. Has the longest range of 
all the current spells but is by far the weakest. Mana Cost: 10MP, Cast Time: Instant, 
Cooldown Time: One Round, Distance 45 yards, Damage: 8 Wind Damage.
     * */

	public GameObject firebolt;
    public float fireboltRange;
    public float fireboltSpeed;
    public float fireboltManaCost;
    public float fireboltDamage;
    public float fireboltCastTime;
    public float fireboltCooldown;

    public GameObject iceLance;
    public float iceLanceRange;
    public float iceLanceSpeed;
    public float iceLanceManaCost;
    public float iceLanceDamage;
    public float iceLanceCastTime;
    public float iceLanceCooldown;
    public float iceLanceHealth;

    public GameObject rockArmor;
    public float rockArmorRange;
    public float rockArmorSpeed;
    public float rockArmorManaCost;
    public float rockArmorDamage;
    public float rockArmorCastTime;
    public float rockArmorCooldown;

    public GameObject gust;
    public float gustRange;
    public float gustSpeed;
    public float gustManaCost;
    public float gustDamage;
    public float gustCastTime;
    public float gustCooldown;


    public bool isCasting;

	public RectTransform magicTransform;
	private float savedYMagic; 
	private float minXValue;
	private float maxXvalue;
	private int currentMagic;

	private int CurrentMagic
	{
		get{return currentMagic;}
		set{
			currentMagic = value;
			HandleMagic();
		}
	}

	public int maxMagic;	
	public Text magicText;
	public Image visualMagic;
	public float coolDown;
	private bool onCD;

	// Use this for initialization
	void Start () 
	{
		savedYMagic = magicTransform.position.y;
		
		maxXvalue = magicTransform.position.x;
		minXValue = magicTransform.position.x - 177;
		
		currentMagic = maxMagic;
		onCD = false;
		
		magicText.text = "Magic: " + currentMagic; 	
	}
	
	// Update is called once per frame
	void Update () {
        castSpells();
	}

    void castSpells()
    {
        if (!isCasting)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))        //Firebolt
            {
				if(!onCD && currentMagic > 0)
				{
					StartCoroutine(CoolDownDmg());
					CurrentMagic -= 1;
                	GameObject fireboltSpell = Instantiate(firebolt, transform.position + new Vector3(0, 1, .5f), Quaternion.identity) as GameObject;
					Transform fireboltTransform = fireboltSpell.transform; 
                	fireboltSpell.GetComponent<Rigidbody>().AddForce(fireboltTransform.forward * fireboltSpeed);
				}           

            }
            if (Input.GetKeyDown(KeyCode.Alpha2))       //Ice Lance
            {
				if(!onCD && currentMagic > 0)
				{
					StartCoroutine(CoolDownDmg());
					CurrentMagic -= 1;
                	GameObject iceLanceSpell = Instantiate(iceLance, transform.position + new Vector3(0, 1, .5f), Quaternion.identity) as GameObject;
               		Transform iceLanceTransform = iceLanceSpell.transform;
                	iceLanceSpell.GetComponent<Rigidbody>().AddForce(iceLanceTransform.forward * iceLanceSpeed);
				}              

            }
            if (Input.GetKeyDown(KeyCode.Alpha3))       //RockArmor
            {
				if(!onCD && currentMagic > 0)
				{
					StartCoroutine(CoolDownDmg());
					CurrentMagic -= 1;
                	GameObject gustSpell = Instantiate(gust, transform.position + new Vector3(0, 1, .5f), Quaternion.identity) as GameObject;
                	Transform gustTransform = gustSpell.transform;
                	gustSpell.GetComponent<Rigidbody>().AddForce(gustTransform.forward * gustSpeed);
				}

            }
            if (Input.GetKeyDown(KeyCode.Alpha4))       //Gust
            {



            }

        }

    }

	void OnTriggerStay(Collider other)
	{
		if(other.name == "Magic")
		{
			if(!onCD && currentMagic < maxMagic)
			{
				StartCoroutine(CoolDownDmg());
				CurrentMagic += 1;
			}
		}
	}

	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds (coolDown);
		onCD = false;
	}

	private void HandleMagic()
	{
		magicText.text = "Magic: " + currentMagic;
		
		float currentXValue = MapValues (currentMagic, 0, maxMagic, minXValue, maxXvalue);
		
		magicTransform.position = new Vector3 (currentXValue, savedYMagic);
	}
	
	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
