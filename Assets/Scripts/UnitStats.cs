using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Random = UnityEngine.Random;

public class UnitStats : MonoBehaviour, IComparable {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject damageTextPrefab;

	[SerializeField]
	private GameObject healTextPrefab;

    [SerializeField]
    private Vector2 damageTextPosition;

	private float statIncreaser;

       public float maxHP;
       public float HP;
       public float maxMP;
       public float MP;
       
    

	public float attack;
	public float magic;
	public float defense;
	public float speed;  

	public int nextActTurn;

	private bool dead = false;

    public float level;
    public float currentExperience;

	void Start() {
        level = 1;
	}

    void Update()
    {
        //Makes it so that current health and mp cannot go above their max values
        HP = Mathf.Clamp(HP, 0, maxHP);
        MP = Mathf.Clamp(MP, 0, maxMP);

        levelUP();
    }



    public void receiveDamage(float damage) {
		this.HP -= damage;
		animator.Play ("Hit");

		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject damageText = Instantiate (this.damageTextPrefab, HUDCanvas.transform) as GameObject;
        damageText.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
		damageText.GetComponent<Text> ().text = "" + damage.ToString("N0");
		damageText.transform.localPosition = this.damageTextPosition;
		damageText.transform.localScale = new Vector2 (1.0f, 1.0f);
     

        if (this.HP <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}
	}

	//for healing
	public void healDamage(float heal) {

		this.HP += heal;

		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject healText = Instantiate (this.healTextPrefab, HUDCanvas.transform) as GameObject;
		healText.GetComponent<Text> ().text = "" + heal.ToString("N0");
		healText.transform.localPosition = this.damageTextPosition;
		healText.transform.localScale = new Vector2 (1.0f, 1.0f);

	}

	public void calculateNextActTurn(int currentTurn) {
		this.nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / this.speed);
	}

	public int CompareTo(object otherStats) {
		return nextActTurn.CompareTo (((UnitStats)otherStats).nextActTurn);
	}

	public bool isDead() {
		return this.dead;
	}

	public void receiveExperience(float experience) {
		this.currentExperience += experience;
	}

    public void levelUP()
	{
		if (currentExperience >= 0 && currentExperience <= 100 && level != 1) {
			level = 1;
		}
		if (currentExperience >= 101 && currentExperience <= 500 && level != 2) {
			level = 2;
			statIncreaser = Random.Range (8, 10);
			maxHP += statIncreaser;

			statIncreaser = Random.Range (2, 3);
			magic += statIncreaser;

			statIncreaser = Random.Range (3, 4);
			attack += statIncreaser;

			statIncreaser = Random.Range (2, 3);
			defense += statIncreaser;

			statIncreaser = Random.Range (3, 4);
			speed += statIncreaser;
		}

		if (currentExperience >= 501 && currentExperience <= 1000 && level != 3) {
			level = 3;
			statIncreaser = Random.Range (8, 10);
			maxHP += statIncreaser;

			statIncreaser = Random.Range (2, 3);
			magic += statIncreaser;

			statIncreaser = Random.Range (3, 4);
			attack += statIncreaser;

			statIncreaser = Random.Range (2, 3);
			defense += statIncreaser;

			statIncreaser = Random.Range (3, 4);
			speed += statIncreaser;
		} 
		if (currentExperience >= 1001 && currentExperience <= 2000 && level != 4) {
			level = 4;
			statIncreaser = Random.Range (8, 10);
			maxHP += statIncreaser;

			statIncreaser = Random.Range (2, 3);
			magic += statIncreaser;

			statIncreaser = Random.Range (3, 4);
			attack += statIncreaser;

			statIncreaser = Random.Range (2, 3);
			defense += statIncreaser;

			statIncreaser = Random.Range (3, 4);
			speed += statIncreaser;
		}

	}
	}
	
