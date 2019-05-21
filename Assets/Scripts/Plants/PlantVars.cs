using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantVars : MonoBehaviour
{
    // constant for each plant type
    public int plantPrice;
    public float rechargeTime;

    // variable for each plant type: will be set during game
    public int lane;

    // shared for each plant type: store in toolbar
    public int timesBought;
    public float lastTimeBought;
}
