﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerUnitAction : MonoBehaviour
{

    [SerializeField]
    private GameObject physicalAttack;

    [SerializeField]
    private GameObject magicalAttack;

    public GameObject Frame;

    private GameObject _instance;

    [SerializeField]
    private string unitName;

    private GameObject currentAttack;

    GameObject playerUnitInformationHUD;

    int getFrameExists;

    void Awake()
    {

        this.physicalAttack = Instantiate(this.physicalAttack, this.transform) as GameObject;
        this.magicalAttack = Instantiate(this.magicalAttack, this.transform) as GameObject;

        this.physicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;
        this.magicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;

        this.currentAttack = this.physicalAttack;
    }



    public void selectAttack(bool physical)
    {
        this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
    }

    public void act(GameObject target)
    {
        this.currentAttack.GetComponent<AttackTarget>().hit(target);
    }

    public void updateHUD()
    {
        int getFrameExists = SetFrameExists.frameExists; 

        if (getFrameExists == 0)
        {
            playerUnitInformationHUD = GameObject.Find("PlayerUnitInformation");
            _instance = Instantiate(this.Frame, this.transform) as GameObject;
            _instance.transform.parent = playerUnitInformationHUD.transform;
            getFrameExists = 1;
        }

        //Unit Frame Information
        GameObject playerUnitName = _instance.transform.Find("PlayerUnitName").gameObject;
        playerUnitName.GetComponent<Text>().text = this.unitName;

        GameObject playerUnitHealthBar = _instance.transform.Find("PlayerUnitHealthBar").gameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHP>().changeUnit(this.gameObject);

        GameObject playerUnitManaBar = _instance.transform.Find("PlayerUnitManaBar").gameObject;
        playerUnitManaBar.GetComponent<ShowUnitMP>().changeUnit(this.gameObject);

        //Changes colour of current unit frame
        GameObject CurrentUnitFrame = _instance;
        CurrentUnitFrame.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F);

    }

}