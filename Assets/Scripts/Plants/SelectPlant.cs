using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private const float greyOutLightness = 0.5f;
    private Color originalColor;
    private float yHeightDraggedObject = 1;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        GetComponent<PlantVars>().lastTimeBought = -1000; // everything affordable
    }

    // Update is called once per frame
    void Update()
    {
        // grey out not affordable plants
        if (plantActive())
        {
            // un-grey out
            gameObject.GetComponent<Renderer>().material.color = originalColor;
        }
        else
        {
            // grey out
            gameObject.GetComponent<Renderer>().material.color = originalColor * greyOutLightness;
        }

        // move seleted object
        if (Globals.Instance.DraggedObject != null)
        {
            // move plant over dragging plane
            Plane plane = new Plane(Vector3.up, Vector3.up * yHeightDraggedObject); // dragging plane
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                Globals.Instance.DraggedObject.transform.position = ray.GetPoint(distance); // distance along the ray
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // show tooltip
        // TODO
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Globals.Instance.SelectedObject == null)
        {
            // select object (to be placed with a click)
            if (plantActive())
            {
                // select & create copy to drag
                Globals.Instance.SelectedObject = gameObject;
                Globals.Instance.DraggedObject = (GameObject)Instantiate(gameObject, transform.position, transform.rotation);
                // disable selected plant
                DisableEnable.Disable(Globals.Instance.DraggedObject);
                // dont raycast dragged object
                Globals.Instance.DraggedObject.layer = 2; // Ignore Raycast Layer
            }
        }
        else // we have an object selected, but are clicking the toolbar
        {
            // unselect plant
            Globals.Instance.SelectedObject = null;
            // destroy dragged object
            Destroy(Globals.Instance.DraggedObject);
            Globals.Instance.DraggedObject = null;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // remove tooltip
        // TODO
    }

    public bool plantActive()
    {
        // returns true if plant is AFFORDABLE and RECHARGED (or never bought)
        PlantVars vars = GetComponent<PlantVars>();
        return Globals.Instance.SunScore >= vars.plantPrice
            && (vars.timesBought == 0
                || Time.time - vars.lastTimeBought >= vars.rechargeTime);
    }
}
