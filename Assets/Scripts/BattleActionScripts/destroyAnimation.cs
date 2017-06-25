using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAnimation : MonoBehaviour {

public void killThis()
{
	UnityEngine.Object.Destroy(this.gameObject);
} 
}
