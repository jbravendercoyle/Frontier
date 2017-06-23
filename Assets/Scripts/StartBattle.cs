using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartBattle : MonoBehaviour
{
    public static GameObject PartyManager;

    //declaring this public may make me able to access this when it is inactive

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        PartyManager = this.gameObject;

        SceneManager.sceneLoaded += OnSceneLoaded;        
        
        this.gameObject.SetActive(false);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Title")
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(this.gameObject);
        }

        else
        {
            this.gameObject.SetActive(scene.name == "Battle");
        }
    } 
}
