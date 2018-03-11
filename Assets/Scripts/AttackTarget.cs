using UnityEngine;
using System.Collections;

public class AttackTarget : MonoBehaviour {

    public enum ArtTypeEnum {martial, blade, fire}
    public ArtTypeEnum ArtType;

	public GameObject owner;

	[SerializeField]
	private string attackAnimation;

	[SerializeField]
	private bool SPAttack;

	[SerializeField]
	private float SPCost;

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
        if (ownerStats.thisUnit.SP >= this.SPCost) {
            float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
            float damage = (this.SPAttack) ? attackMultiplier * ownerStats.thisUnit.magic : attackMultiplier * ownerStats.thisUnit.attack;

            float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
            damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.thisUnit.defense));

            this.owner.GetComponent<Animator>().Play(this.attackAnimation);

            targetStats.receiveDamage(damage);

            ownerStats.thisUnit.SP -= this.SPCost;
		}        
	}
}
