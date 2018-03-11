using UnityEngine;
using System.Collections;

public class ShowUnitHP : ShowUnitStat {

	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().thisUnit.HP;
	}

    override protected float maxStatValue()
    {
        return unit.GetComponent<UnitStats>().thisUnit.maxHP;
    }
}
