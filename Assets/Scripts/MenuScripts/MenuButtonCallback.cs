using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuButtonCallback : MonoBehaviour {

    bool ItemPanelOpen;

    // Use this for initialization
    void Start() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => OpenItemMenu());
        ItemPanelOpen = true;
    }

    // Update is called once per frame
    private void OpenItemMenu () {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<CharacterMenu>().Items();
	}

    private void CloseItemMenu()
    {
        GameObject Player = GameObject.Find("Player");
        Player.GetComponent<CharacterMenu>().CloseItems();
        ItemPanelOpen = false;
    }
}
