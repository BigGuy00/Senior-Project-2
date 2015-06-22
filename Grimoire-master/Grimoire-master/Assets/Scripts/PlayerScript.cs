using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public RectTransform healthTransform;
	private float savedYHealth;
	private float minXValue;
	private float maxXvalue;
	private int currentHealth;

	private int CurrentHealth
	{
		get{return currentHealth;}
		set{
			currentHealth = value;
			HandleHealth();
		}
	}


	public int maxHealth;
	public Text healthText;
	public Image visualHealth;
	public float coolDown;
	private bool onCD;

	// Use this for initialization
	void Start () 
	{
		savedYHealth = healthTransform.position.y;

		maxXvalue = healthTransform.position.x;
		minXValue = healthTransform.position.x - 177;

		currentHealth = maxHealth;
		onCD = false;

		healthText.text = "Health: " + currentHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	void OnTriggerStay(Collider other)
	{
		if(other.name == "Health")
		{
			if(!onCD && currentHealth < maxHealth)
			{
				StartCoroutine(CoolDownDmg());
				CurrentHealth += 1;
			}
		}
		if(other.name == "Damage")
		{
			if(!onCD && currentHealth > 0)
			{
				StartCoroutine(CoolDownDmg());
				CurrentHealth -= 1;
			}
		}
	}

	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds (coolDown);
		onCD = false;
	}

	private void HandleHealth()
	{
		healthText.text = "Health: " + currentHealth;

		float currentXValue = MapValues (currentHealth, 0, maxHealth, minXValue, maxXvalue);

		healthTransform.position = new Vector3 (currentXValue, savedYHealth);
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
