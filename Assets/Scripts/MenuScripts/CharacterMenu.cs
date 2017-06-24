using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterMenu : MonoBehaviour {

    public GameObject HUDCanvas;
    public GameObject CharacterPanel;
    public GameObject Inventory;

    public static bool MenuOpened;

    public GameObject PlayerParty;


    void Update () {


        if (Input.GetButton("Menu"))
        {
            this.HUDCanvas.SetActive(true);
            MenuOpened = true;
            PlayerControllerNEO component = this.gameObject.GetComponent<PlayerControllerNEO>();
            component.enabled = false;            
        }

        if (Input.GetButton("Cancel") && (MenuOpened == true))
        {
            this.HUDCanvas.SetActive(false);
            MenuOpened = false;
            PlayerControllerNEO component = this.gameObject.GetComponent<PlayerControllerNEO>();
            component.enabled = true;
        } 

    } 

    public void Items()
    {
        this.CharacterPanel.SetActive(false);
        this.Inventory.SetActive(true);
    } 

    public void Status()
    {
        this.Inventory.SetActive(false);
        this.CharacterPanel.SetActive(true);
                
    }
}
