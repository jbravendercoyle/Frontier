using UnityEngine;
using System.Collections;
using System.Linq;
//using UnityEngine;

public class AttackTarget : MonoBehaviour {

	public GameObject owner;

	public GameObject attackAnimator;
	private GameObject _attackInstance;
	public GameObject ParticleEffect;
	private GameObject _ParticleInstance;


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

	//[SerializeField]
	//private float MPCost;

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
		pos2 = target.transform.position;

		//

		UnitStats ownerStats = this.owner.GetComponent<UnitStats> ();
		UnitStats targetStats = target.GetComponent<UnitStats> ();
		if (ownerStats.MPArray[0] >= 1) {
			float attackMultiplier = (Random.value * (this.maxAttackMultiplier - this.minAttackMultiplier)) + this.minAttackMultiplier;
			float damage = (this.MPAttack) ? attackMultiplier * ownerStats.magic : attackMultiplier * ownerStats.attack;

			float defenseMultiplier = (Random.value * (this.maxDefenseMultiplier - this.minDefenseMultiplier)) + this.minDefenseMultiplier;
			damage = Mathf.Max(0, damage - (defenseMultiplier * targetStats.defense));

			if (!FlyingSickle & !MPAttack) {
				//move attacker to target then back
				//owner.transform.position = Vector3.Lerp (pos1, pos2, 1);
				StartCoroutine (Attacker (pos1, pos2, 0.4f));
				//play attack on enemy
				_attackInstance = Instantiate(this.attackAnimator, target.gameObject.transform);
				//_attackInstance.transform.SetParent(target.gameObject.transform);
				_attackInstance.GetComponent<Animator> ().Play (this.attackAnimatorAnimation);
				//Destroy(_attackInstance);
				DestroyObject(_attackInstance);
			}

			//Animates a flying sickle
			if (FlyingSickle == true) {
				SickleChild = this.owner.transform.GetChild (0);
				SickleChild.gameObject.SetActive (true);
				sicklePos1 = SickleChild.transform.position;

				//Vector3 direction = pos2 - pos1;
				//float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
				//SickleChild.transform.rotation = Quaternion.AngleAxis(angle, pos2);

				StartCoroutine (Flyer (sicklePos1, pos2, 0.4f));
				SickleChild.GetComponent<Animator> ().Play (animatorForFlyingSickle);
			} 

			//if its a magic attack, instantiate the particle effect on the enemy.
			if (!FlyingSickle & MPAttack) {
				StartCoroutine (ParticleAttack (sicklePos1, pos2, 0.4f, target));
				_ParticleInstance = Instantiate (this.ParticleEffect, target.gameObject.transform);

				ParticleSystem explode = _ParticleInstance.GetComponent<ParticleSystem>();

				explode.Play();
				Destroy(_ParticleInstance, explode.duration);

			}

			//play owners animation 
			this.owner.GetComponent<Animator> ().Play (this.attackAnimation);




			targetStats.receiveDamage (damage);
			ownerStats.MPArray [0] -= -1;
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

	IEnumerator ParticleAttack(Vector3 pos1, Vector3 pos2, float overTime, GameObject target)
	{ 
		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{ 
				ParticleEffect.transform.position = Vector3.Lerp (pos1, pos2, (Time.time - startTime) / overTime); 
				target.gameObject.GetComponent<SpriteRenderer> ().color = (Color.red);
			yield return null;

		} 
		ParticleEffect.transform.position = Vector3.Lerp (pos2, pos1, (Time.time - startTime)/overTime);
		yield return new WaitForSeconds (1f);
		target.gameObject.GetComponent<SpriteRenderer> ().color = (Color.white);
	}

	IEnumerator Flyer(Vector3 pos1, Vector3 pos2, float overTime)
	{


		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{			
			SickleChild.transform.position = Vector3.Lerp (SickleChild.transform.position, pos2, Mathf.SmoothStep(0.1f, 1.0f, 0.2f * Time.deltaTime));

			yield return new WaitForSeconds (0.2f);
			yield return null;
		} 
		SickleChild.gameObject.SetActive (false);
		//SickleChild.transform.localScale = Vector3.Lerp (pos2, pos1, (Time.time - startTime)/overTime);


	}

}