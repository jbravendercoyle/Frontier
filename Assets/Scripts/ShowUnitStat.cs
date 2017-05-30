using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class ShowUnitStat : MonoBehaviour {

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

	public void changeUnit(GameObject newUnit) {
		this.unit = newUnit;
	}

	abstract protected float newStatValue();
    abstract protected float maxStatValue();
}
