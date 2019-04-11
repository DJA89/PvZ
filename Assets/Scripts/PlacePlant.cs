using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacePlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    //public GameObject CellContainer;
    private Renderer cellRenderer;

    private Color cellColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        cellRenderer = gameObject.GetComponent<Renderer>();
        cellRenderer.material.color = Color.red;
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
