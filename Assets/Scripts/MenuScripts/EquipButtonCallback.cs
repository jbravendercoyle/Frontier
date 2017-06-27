using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EquipButtonCallback : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => OpenEquipMenu());


    }

    // Update is called once per frame
    private void OpenEquipMenu()
    {
        GameObject Player = GameObject.Find("Player");

            Player.GetComponent<CharacterMenu>().Equip();
        }
    }

