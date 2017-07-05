using UnityEngine;
using System.Collections;

public class ShowUnitMP : ShowUnitStatMP {

	override protected int []MPArrayValue() { 
			return unit.GetComponent<UnitStats> ().MPArray;
	}
	override protected int []MPArrayNewValue()
    {
		return unit.GetComponent<UnitStats> ().MPArrayMax;  
}
}