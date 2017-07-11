using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		//SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	// Update is called once per frame
//	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
//		if (scene.name == "Battle") {
//			SceneManager.sceneLoaded -= OnSceneLoaded;
//			this.gameObject.SetActive (false);
//		}
//		else {
//			this.gameObject.SetActive (true);
//	}
//}
}