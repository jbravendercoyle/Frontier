using UnityEngine;
using System.Collections;

public class ShowUnitHP : ShowUnitStatHP {

	override protected float newStatValue() {

			return unit.GetComponent<UnitStats> ().HP;
	}

	override protected float maxStatValue()
    {
			return unit.GetComponent<UnitStats> ().maxHP;

    }
}
