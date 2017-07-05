using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public abstract class ShowUnitStatMP: MonoBehaviour {

	[SerializeField]
	protected GameObject unit;

    Text healthvaluetext;

	void Start() {
    }

	void Update() {
		if (this.unit) {

		    
			int []MPArrayValue = this.MPArrayValue();
			int[]MPArrayNewValue = this.MPArrayNewValue();
			this.gameObject.GetComponent<Text> ().text = string.Join (", ", MPArrayValue.Select (i => i.ToString ()).ToArray ());

        }
	}

    //Removed 'change unit' function as all party members hp will always be shown on screen
	public void changeUnit(GameObject newUnit) {
		this.unit = newUnit;
	}
		
	abstract protected int []MPArrayValue();
	abstract protected int []MPArrayNewValue();
}
