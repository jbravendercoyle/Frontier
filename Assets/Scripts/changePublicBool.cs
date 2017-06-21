using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePublicBool : MonoBehaviour {

    bool onetime;

void OnDestroy()
    {
        onetime = SelectUnit.onetime;
        onetime = false;
    }
}
