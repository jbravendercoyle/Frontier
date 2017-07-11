using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoFiteButton : MonoBehaviour {


	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());

	}

	private void addCallback() {
		AutoFite component = this.gameObject.GetComponent<AutoFite>();
		component.enabled = true; 

	}

}

