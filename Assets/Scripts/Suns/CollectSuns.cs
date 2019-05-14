using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectSuns : MonoBehaviour, IPointerClickHandler
{
    public int sunValue = 50;
    public AudioClip sound;

    private float collectionSpeed = 5f; // in Time.deltaTime

    private bool collected = false;

    // this sun clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // move towards sun score (without gravity)
        collected = true;
        transform.GetComponent<Rigidbody>().useGravity = false;
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

    private void Update()
    {
        if (collected)
        {
            // move towards sun collection point
            Transform collectionPoint = Globals.Instance.SunIcon.transform.GetChild(0);
            transform.position = Vector3.Lerp(transform.position, collectionPoint.position, collectionSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if colliding with sun icon
        if (collision.transform.gameObject == Globals.Instance.SunIcon)
        {
            // add sun value to sun score
            Globals.Instance.SunScore += sunValue;
            // remove collected sun (parent of this)
            Destroy(transform.parent.gameObject);
        }
    }
}
