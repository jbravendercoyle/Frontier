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
    public float maxLP;
    public float LP;
    public float maxSP;
    public float SP;

	public float attack;
	public float magic;
	public float defense;
	public float speed;  

	public int nextActTurn;

	private bool dead = false;

	private float currentExperience;

	void Start() {
		
	}

    void Update()
    {
        //Makes it so that current health, lp and sp cannot go above their max values
        HP = Mathf.Clamp(HP, 0, maxHP);
        LP = Mathf.Clamp(LP, 0, maxLP);
        SP = Mathf.Clamp(SP, 0, maxSP);
    }
    public void receiveDamage(float damage) {
		this.HP -= damage;
		animator.Play ("Hit");

		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject damageText = Instantiate (this.damageTextPrefab, HUDCanvas.transform) as GameObject;
		damageText.GetComponent<Text> ().text = "" + damage;
		damageText.transform.localPosition = this.damageTextPosition;
		damageText.transform.localScale = new Vector2 (1.0f, 1.0f);

		if (this.HP <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}

        if (this.LP <=0)
        {
            this.dead = true;
            this.gameObject.tag = "DeadUnit";
            Destroy(this.gameObject);
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

	public void receiveExperience(float experience) {
		this.currentExperience += experience;
	}
}
