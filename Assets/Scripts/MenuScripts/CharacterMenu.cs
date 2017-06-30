using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterMenu : MonoBehaviour {

    public GameObject HUDCanvas;
    public GameObject CharacterPanel;
    public GameObject Inventory;
	public GameObject OpenEquip;

    public static bool MenuOpened;

    public GameObject PlayerParty;


    void Update () {


        if (Input.GetButton("Menu"))
        {
            this.HUDCanvas.SetActive(true);
            MenuOpened = true;
            PlayerMovement component = this.gameObject.GetComponent<PlayerMovement>();
            component.enabled = false;            
        }

        if (Input.GetButton("Cancel") && (MenuOpened == true))
        {
            this.HUDCanvas.SetActive(false);
            MenuOpened = false;
			PlayerMovement component = this.gameObject.GetComponent<PlayerMovement>();
            component.enabled = true;
        } 

    } 


	//Opens Items Panel, closes Inventory
    public void Items()
    {
		
        Inventory.SetActive(true);

		if (CharacterPanel.activeInHierarchy == true)
		{
			CharacterPanel.SetActive(false);
		}
		if (OpenEquip.activeInHierarchy == true)
		{
			OpenEquip.SetActive(false);
		}		
    } 

	//Opens Items, closes Character Panel
    public void Status()
    {
        CharacterPanel.SetActive(true);
                
		if (OpenEquip.activeInHierarchy == true)
		{
			OpenEquip.SetActive(false);
		}
		if (Inventory.activeInHierarchy == true)
		{
			Inventory.SetActive(false);
		}		
    }

	//Opens Equip, closes Character Panel and Inventory
	public void Equip()
	{
		OpenEquip.SetActive (true);

		if (CharacterPanel.activeInHierarchy == true)
		{
			CharacterPanel.SetActive(false);
		}
		if (Inventory.activeInHierarchy == true)
		{
			Inventory.SetActive(false);
		}			
}
}