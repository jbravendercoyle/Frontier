using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

	public string ItemName;
	public float quantity;

	public float healValue;

	private string description;

	// Use this for initialization
	void Awake () {
		ItemName = "Potion";
		healValue = 50f;
		description = "A Fast-Acting Health Potion. Heals you up real good. (For 50HP)";
		Mathf.Clamp (quantity, 0, 99);
	}
	
	// Update is called once per frame
	void Update () {

		if (quantity == 0)
		{
			
		}
	}
}
