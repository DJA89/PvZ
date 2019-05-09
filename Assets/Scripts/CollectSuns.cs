using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectSuns : MonoBehaviour, IPointerClickHandler
{
    public static readonly int SUN_VALUE = 50;

    // this sun clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("sun clicked");
        // add sun value to sun score
        Globals.Instance.SunScore += SUN_VALUE;
        // remove sun
        Destroy(gameObject);
    }
}
