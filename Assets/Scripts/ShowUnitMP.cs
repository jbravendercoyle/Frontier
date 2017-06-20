using UnityEngine;
using System.Collections;

public class ShowUnitMP : ShowUnitStat {

	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().MP;
	}

    override protected float maxStatValue()
    {
        return unit.GetComponent<UnitStats>().maxMP;
    }
}
