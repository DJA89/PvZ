using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacePlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject plant1Template;

    private GameObject currentPlant;

    private Renderer cellRenderer;
    private Color cellColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        cellRenderer = gameObject.GetComponent<Renderer>();
        cellRenderer.material.color = Color.red;

        // if has no plant already there...
        if (transform.childCount == 0) // no children => cell free
        {
            // ...spawn a plant!
            Vector3 plantSpawnPoint = new Vector3(0.0f, 0.0f, -0.75f); // relative to (parent) cell
            GameObject newPlant = (GameObject)Instantiate(plant1Template, plantSpawnPoint + transform.position, transform.rotation, transform);
            // divide by absolute (lossy) cell scale (otherwise plant gets squashed)
            Vector3 newPlantScale = newPlant.transform.localScale;
            newPlantScale.x /= transform.lossyScale.x;
            newPlantScale.y /= transform.lossyScale.y;
            newPlantScale.z /= transform.lossyScale.z;
            newPlant.transform.localScale = newPlantScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cellRenderer = gameObject.GetComponent<Renderer>();
        cellRenderer.material.color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cellRenderer = gameObject.GetComponent<Renderer>();
        //cellRenderer.material.color = Color.black;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
