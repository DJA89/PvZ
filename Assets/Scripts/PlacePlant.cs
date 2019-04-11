using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacePlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject plant1Template;

    private Renderer cellRenderer;

    private Color cellColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        cellRenderer = gameObject.GetComponent<Renderer>();
        cellRenderer.material.color = Color.red;

        // if has no plant already spawn a plant
        //if (KeyNotFoundException plant)
        // as the shots are spawned as CHILDREN of the Plant, they automatically inherit the plant.transform
        Vector3 plantSpawn = new Vector3(0.0f, 0.0f, -0.75f);
        GameObject newPlant = (GameObject)Instantiate(plant1Template, plantSpawn + transform.position, transform.rotation, transform);
        //objToSpawn = new GameObject("Cool GameObject made from Code");
        // divide by absolute cell scale (otherwise plant gets squashed)
        Vector3 newPlantScale = newPlant.transform.localScale;
        newPlantScale.x /= transform.lossyScale.x;
        newPlantScale.y /= transform.lossyScale.y;
        newPlantScale.z /= transform.lossyScale.z;
        newPlant.transform.localScale = newPlantScale;
        //print(newPlant.transform.position.x);
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
