using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStats : MonoBehaviour, IComparable {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject damageTextPrefab;

    [SerializeField]
    private Vector2 damageTextPosition;

    
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

    private bool needToLevel;
    public float level;
    public float currentExperience;

	void Start() {
        level = 1;
        needToLevel = false;
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
		damageText.GetComponent<Text> ().text = "" + damage;
		damageText.transform.localPosition = this.damageTextPosition;
		damageText.transform.localScale = new Vector2 (1.0f, 1.0f);
     

        if (this.HP <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}
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

    public void levelUP()
    {
        if (currentExperience >= 0 && currentExperience <= 100 && level != 1)
        {
            level = 1;
        }
        else if (currentExperience >= 101 && currentExperience <= 500 && level != 2)
        {
            level = 2;
        }
}
	public void receiveExperience(float experience) {
		this.currentExperience += experience;
	}
}
