using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterMenu : MonoBehaviour {

    public GameObject HUDCanvas;

    StartBattle SB;

	// Use this for initialization
	void Awake () {

    }

    //void Start()
    //{
    //    
    //}

    // Update is called once per frame
    void Update () {


        if (Input.GetButton("Menu"))
            this.HUDCanvas.SetActive(true);
        //{
          //  StartBattle.SB.HereWeGo();
        //}

        if (Input.GetButton("Cancel"))
            this.HUDCanvas.SetActive(false);
        //{
        //    StartBattle.SB.Shutdown();
        //}
    }
}
