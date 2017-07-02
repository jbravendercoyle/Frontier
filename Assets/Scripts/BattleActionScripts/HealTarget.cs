using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTarget : MonoBehaviour {

	public GameObject owner;
	public GameObject healAnimator; //Healing Animation
	private GameObject _healInstance; //Instantiate HealAnimation

	private float HealValue; //How much does this heal heal

	[SerializeField]
	private string healAnimation; //Specify Healing animation string for PlayerUnit

	[SerializeField]
	private string healAnimatorAnimation; //Specifiy aniation string played on Target

	[SerializeField]
	private bool MPAttack; //does this heal move cost MP?

	[SerializeField]
	private float MPCost; //how much magic does this heal move cost, MP-wise.

	public void healTarget(GameObject target){

		owner = target;

		UnitStats ownerStats = this.owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		if (ownerStats.MP >= this.MPCost) {

			HealValue = this.gameObject.GetComponent<Potion>().healValue;

			this.owner.GetComponent<Animator> ().Play (this.healAnimation);

			targetStats.healDamage (HealValue);
			ownerStats.MP -= this.MPCost;
		}
	}
}