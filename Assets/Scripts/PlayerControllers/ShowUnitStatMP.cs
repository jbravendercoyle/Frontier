using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public abstract class ShowUnitStatHP : MonoBehaviour {

	[SerializeField]
	protected GameObject unit;

    Text healthvaluetext;

	void Start() {
    }

	void Update() {
		if (this.unit) {
			float newValue = this.newStatValue();
			float maxValue = this.maxStatValue();
            this.gameObject.GetComponent<Text>().text = newValue.ToString("N0") + "/" + maxValue;

        }
	}

    //Removed 'change unit' function as all party members hp will always be shown on screen
	public void changeUnit(GameObject newUnit) {
		this.unit = newUnit;
	}
		
	abstract protected float newStatValue();
	abstract protected float maxStatValue();
}
