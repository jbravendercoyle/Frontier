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
            PlayerController component = this.gameObject.GetComponent<PlayerController>();
            component.enabled = false;            
        }

        if (Input.GetButton("Cancel"))
        {
            this.HUDCanvas.SetActive(false);
            MenuOpened = false;
            PlayerController component = this.gameObject.GetComponent<PlayerController>();
            component.enabled = true;
        } 

    } 

    public void Items()
    {
        this.CharacterPanel.SetActive(false);
        this.Inventory.SetActive(true);
    } 

    public void CloseItems()
    {
        this.CharacterPanel.SetActive(true);
        this.Inventory.SetActive(false);
    }
}
