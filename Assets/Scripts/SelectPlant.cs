using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler
{
    //public GameObject plant1Template;

    private GameObject plantDragged;
    private Transform m_DraggingPlane;

    private Renderer cellRenderer;
    private Color cellColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // show tooltip


        //cellRenderer = gameObject.GetComponent<Renderer>();
        //cellRenderer.material.color = Color.blue;

        //// no children => cell free
        //if (transform.childCount == 0) // no children => cell free
        //{
        //    float transparency = 0.5f;
        //    // show shadow of plant
        //    plantShadow = spawnPlant(); // spawn
        //    SetRendererAlphas(transparency, GetComponentsInChildren<Renderer>()); // make semi-transparent
        //    plantShadow.GetComponent<Shoot>().enabled = false; // don't shoot
        //}
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // create copy to select

        // make non-selectable
        //Destroy(newPlant.GetComponent<SelectPlant>());
        SelectionManager.Instance.Selected = gameObject;

        print("selected: " + gameObject);

        //cellRenderer = gameObject.GetComponent<Renderer>();
        //cellRenderer.material.color = Color.red;

        //// only shadow present?
        //if (transform.childCount == 1 && transform.GetChild(0).gameObject == plantShadow)
        //{
        //    // remove shadow
        //    Destroy(plantShadow);
        //    plantShadow = null;
        //    // spawn real plant
        //    GameObject newPlant = spawnPlant();
        //}
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // remove tooltip


        //// if we have a shadow
        //if (plantShadow != null)
        //{
        //    // remove shadow
        //    Destroy(plantShadow);
        //    plantShadow = null;
        //}
    }

    public void OnSelect(BaseEventData eventData)
    {
        //plantDragged = spawnPlant(); // spawn
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //if (plantDragged != null)
        //{
        //    plantDragged.GetComponent<Shoot>().enabled = false; // don't shoot
        //    //// remove shadow
        //    //Destroy(plantDragged);
        //    //plantDragged = null;
        //}
    }

    private void SetRendererAlphas(float alpha, Renderer[] mRenderers)
    {
        // from https://answers.unity.com/questions/1031416/make-a-complex-object-semi-transparent-without-cha.html
        for (int i = 0; i < mRenderers.Length; i++)
        {
            for (int j = 0; j < mRenderers[i].materials.Length; j++)
            {
                Color matColor = mRenderers[i].materials[j].color;
                matColor.a = alpha;
                mRenderers[i].materials[j].color = matColor;
            }
        }
    }

    private GameObject spawnPlant()
    {
        Vector3 plantSpawnPoint = new Vector3(0.0f, 0.0f, -0.75f); // relative to (parent) cell
        GameObject newPlant = (GameObject)Instantiate(gameObject, plantSpawnPoint + transform.position, transform.rotation, transform);
        // divide by absolute (lossy) cell scale (otherwise plant gets squashed)
        Vector3 newPlantScale = newPlant.transform.localScale;
        newPlantScale.x /= transform.lossyScale.x;
        newPlantScale.y /= transform.lossyScale.y;
        newPlantScale.z /= transform.lossyScale.z;
        newPlant.transform.localScale = newPlantScale;
        return newPlant;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        // ungrey source tile, stop moving plant, place plant
        Debug.Log("OnEndDrag");

        //cellRenderer = gameObject.GetComponent<Renderer>();
        //cellRenderer.material.color = Color.red;

        //// if we have a dragged object
        //if (plantDragged != null)
        //{
        //    // remove shadow
        //    Destroy(plantDragged);
        //    plantDragged = null;
        //}
    }

    private void SetDraggedPosition(PointerEventData data)
    {
        //// adapted from https://docs.unity3d.com/ScriptReference/EventSystems.IDragHandler.html
        //if (data.pointerEnter != null && data.pointerEnter.transform != null)
        //    m_DraggingPlane = data.pointerEnter.transform;

        //var rt = plantDragged.transform;
        //Vector3 globalMousePos;
        //if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        //{

        //    rt.position = globalMousePos;
        //    rt.rotation = m_DraggingPlane.rotation;
        //}
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // grey source tile, start moving plant
        Debug.Log("OnBeginDrag");

        //cellRenderer = gameObject.GetComponent<Renderer>();
        //cellRenderer.material.color = Color.blue;

        //// create dragged copy (no shooting)
        //GameObject newPlant = spawnPlant();
        //plantDragged.GetComponent<Shoot>().enabled = false; // don't shoot
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move plant
        Debug.Log("OnDrag");

        //// if we have a shadow
        //if (plantDragged != null)
        //{
        //    SetDraggedPosition(eventData);
        //}
    }

}
