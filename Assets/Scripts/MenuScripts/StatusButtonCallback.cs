using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StatusButtonCallback : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(() => OpenStatusMenu());


    }

    // Update is called once per frame
    private void OpenStatusMenu()
    {
        GameObject Player = GameObject.Find("Player");

            Player.GetComponent<CharacterMenu>().Status();
        }
    }

