using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapChange : MonoBehaviour {

	public int sceneIndex;

	public void LoadByIndex (int sceneIndex)
	{
		SceneManager.LoadScene (sceneIndex);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {

			LoadByIndex (sceneIndex);
		}
	}
}