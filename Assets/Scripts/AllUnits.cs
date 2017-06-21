using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class AllUnits : MonoBehaviour
{

    public GameObject[] allUnits;
    // Use this for initialization

    void Awake()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void Update()
    {
        allUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle")
        {
            CreateFrames();
        }
    }

    public void CreateFrames()
    {

        foreach (GameObject unit in allUnits)
        {
            this.GetComponent<PlayerUnitAction>().createFrames();
        }
    }

}