using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterMenu : MonoBehaviour {

    public GameObject HUDCanvas;


	// Use this for initialization
	void Awake () {
        
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButton("Menu"))
            this.HUDCanvas.SetActive(true);

        if (Input.GetButton("Cancel"))
            this.HUDCanvas.SetActive(false);
    }
}
