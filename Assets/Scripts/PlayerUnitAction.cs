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
    public string unitName;

    int frameSpacer;

    private GameObject currentAttack;

    GameObject playerUnitInformationHUD;


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


    public void createFrames()
    {
        frameSpacer = SelectUnit.frameSpacer;

        playerUnitInformationHUD = GameObject.Find("PlayerUnitInformation");


        //determines how each frame is spaced
        if (frameSpacer == 0)
        {
            _instance = Instantiate(this.Frame, new Vector3(-200F, -294), Quaternion.identity);
            _instance.transform.SetParent(playerUnitInformationHUD.transform, false);
        }

        if (frameSpacer == 1)
        {
            _instance = Instantiate(this.Frame, new Vector3(400F, -294), Quaternion.identity);
            _instance.transform.SetParent(playerUnitInformationHUD.transform, false);
        }

        //Unit Frame Information
        GameObject playerUnitName = _instance.transform.Find("PlayerUnitName").gameObject;
            playerUnitName.GetComponent<Text>().text = this.unitName;

            GameObject playerUnitHealthBar = _instance.transform.Find("PlayerUnitHealthBar").gameObject;
            playerUnitHealthBar.GetComponent<ShowUnitHP>().changeUnit(this.gameObject);

            GameObject playerUnitManaBar = _instance.transform.Find("PlayerUnitManaBar").gameObject;
            playerUnitManaBar.GetComponent<ShowUnitMP>().changeUnit(this.gameObject);

        //hopefully, set default colour for frame
        GameObject CurrentUnitFrame = this._instance;
        CurrentUnitFrame.GetComponent<Image>().color = new Color(152, 134, 76, 255);

    }

    public void updateHUD()
    {
        //Changes colour of current unit frame
        GameObject CurrentUnitFrame = this._instance;
        CurrentUnitFrame.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F);
    }

    public void returnColor()
    {
        //hopefully, set default colour for frame
        GameObject CurrentUnitFrame = this._instance;
        CurrentUnitFrame.GetComponent<Image>().color = new Color(152, 134, 76, 255);
    }
}