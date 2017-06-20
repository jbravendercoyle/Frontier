using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

	public GameObject owner;

	[SerializeField]
	private string attackAnimation;

	[SerializeField]
	private bool MPAttack;

	[SerializeField]
	private float MPCost;

	[SerializeField]
	private float minAttackMultiplier;

	[SerializeField]
	private float maxAttackMultiplier;

	[SerializeField]
	private float minDefenseMultiplier;

	[SerializeField]
	private float maxDefenseMultiplier;
	
	public void hit(GameObject target) {
		UnitStats ownerStats = this.owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		if (ownerStats.MP >= this.MPCost) {
			float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
			float damage = (this.MPAttack) ? attackMultiplier * ownerStats.magic : attackMultiplier * ownerStats.attack;

			float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);

			targetStats.receiveDamage (damage);

			ownerStats.MP -= this.MPCost;
		}
	}
}
