using UnityEngine;
using System.Collections;

public class ShowUnitHealth : ShowUnitStat {

	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().health;
	}

    override protected float maxStatValue()
    {
        return unit.GetComponent<UnitStats>().maxHP;
    }
}
