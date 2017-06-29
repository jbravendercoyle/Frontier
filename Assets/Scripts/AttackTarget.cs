using UnityEngine;
using System.Collections;
using System.Linq;

public class AttackTarget : MonoBehaviour {

	public GameObject owner;

	public GameObject attackAnimator;
	private GameObject _attackInstance;


	//For Sickle
	private Transform SickleChild;
	private Vector3 sicklePos1;


	//moving unit testing
	private Vector3 pos1;
	private Vector3 pos2;

	[SerializeField]
	private string attackAnimation;

	[SerializeField]
	private string attackAnimatorAnimation;

	[SerializeField]
	private string animatorForFlyingSickle;

	[SerializeField]
	private bool MPAttack;

	[SerializeField]
	public bool FlyingSickle;

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

		//random move stuff
		pos1 = owner.transform.position;
		pos2 = target.transform.position - new Vector3 (-7, 0, 0);
		//

		UnitStats ownerStats = this.owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		if (ownerStats.MP >= this.MPCost) {
			float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
			float damage = (this.MPAttack) ? attackMultiplier * ownerStats.magic : attackMultiplier * ownerStats.attack;

			float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

			if (!FlyingSickle) {
				//move attacker to target then back
				//owner.transform.position = Vector3.Lerp (pos1, pos2, 1);
				StartCoroutine (Attacker (pos1, pos2, 0.4f));

			}

			//Animates a flying sickle
			if (FlyingSickle == true) {
				SickleChild = this.owner.transform.GetChild (0);
				SickleChild.gameObject.SetActive (true);
				sicklePos1 = SickleChild.transform.position;
				StartCoroutine (Flyer (sicklePos1, pos2, 0.4f));
				SickleChild.GetComponent<Animator> ().Play (animatorForFlyingSickle);
			}

			//play owners animation 
			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);


			//play attack on enemy
			_attackInstance = Instantiate(this.attackAnimator, target.gameObject.transform);
			//_attackInstance.transform.SetParent(target.gameObject.transform);
			_attackInstance.GetComponent<Animator> ().Play (this.attackAnimatorAnimation);
			//Destroy(_attackInstance);


			targetStats.receiveDamage (damage);

			ownerStats.MP -= this.MPCost;
		} 
	}
		
		IEnumerator Attacker(Vector3 pos1, Vector3 pos2, float overTime)
		{
			float startTime = Time.time;
			while(Time.time < startTime + overTime)
			{
				owner.transform.position = Vector3.Lerp (pos1, pos2, (Time.time - startTime)/overTime);
				yield return null;
	} 
		owner.transform.position = Vector3.Lerp (pos2, pos1, (Time.time - startTime)/overTime);


}

	IEnumerator Flyer(Vector3 pos1, Vector3 pos2, float overTime)
	{
		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{
			SickleChild.transform.position = Vector3.Lerp (pos1, pos2, (Time.time - startTime)/overTime);
			//SickleChild.transform.localScale = Vector3.Lerp (pos1, pos2, (Time.time - startTime)/overTime);

			yield return null;
		} 
		SickleChild.transform.position = Vector3.Lerp (pos2, pos1, (Time.time - startTime)/overTime);
		//SickleChild.transform.localScale = Vector3.Lerp (pos2, pos1, (Time.time - startTime)/overTime);

		SickleChild.gameObject.SetActive (false);
	}
}