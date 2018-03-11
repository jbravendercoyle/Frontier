using UnityEngine;
using System.Collections;

public class ShowUnitLP : ShowUnitStat {

	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().thisUnit.LP;
	}

    override protected float maxStatValue()
    {
        return unit.GetComponent<UnitStats>().thisUnit.maxLP;
    }
}
