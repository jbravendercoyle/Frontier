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


    public UnitStatistics thisUnit = new UnitStatistics();

	public int nextActTurn;

	private bool dead = false;

	private float currentExperience;

	void Start() {
		
	}

    void Update()
    {
        //Makes it so that current health, lp and sp cannot go above their max values
        thisUnit.HP = Mathf.Clamp(thisUnit.HP, 0, thisUnit.maxHP);
        thisUnit.LP = Mathf.Clamp(thisUnit.LP, 0, thisUnit.maxLP);
        thisUnit.WP = Mathf.Clamp(thisUnit.WP, 0, thisUnit.maxWP);
        thisUnit.SP = Mathf.Clamp(thisUnit.SP, 0, thisUnit.maxSP);
    }
    public void receiveDamage(float damage) {
        thisUnit.HP -= damage;
		animator.Play ("Hit");

		GameObject HUDCanvas = GameObject.Find ("HUDCanvas");
		GameObject damageText = Instantiate (this.damageTextPrefab, HUDCanvas.transform) as GameObject;
		damageText.GetComponent<Text> ().text = "" + damage.ToString("N0");
		damageText.transform.localPosition = this.damageTextPosition;
		damageText.transform.localScale = new Vector2 (1.0f, 1.0f);

		if (thisUnit.HP <= 0) {
			this.dead = true;
			this.gameObject.tag = "DeadUnit";
			Destroy (this.gameObject);
		}

        if (thisUnit.LP <=0)
        {
            this.dead = true;
            this.gameObject.tag = "DeadUnit";
            Destroy(this.gameObject);
        }
	}

	public void calculateNextActTurn(int currentTurn) {
		this.nextActTurn = currentTurn + (int)Math.Ceiling(100.0f / thisUnit.speed);
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
