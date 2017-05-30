using UnityEngine;
using System.Collections;

public class ShowUnitMana : ShowUnitStat {

	override protected float newStatValue() {
		return unit.GetComponent<UnitStats> ().mana;
	}

    override protected float maxStatValue()
    {
        return unit.GetComponent<UnitStats>().maxHP;
    }
}
