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
    }

    // Update is called once per frame
    void Update()
    {
        // grey out not affordable plants
        if (Globals.Instance.SunScore < gameObject.GetComponent<PlantVars>().plantPrice)
        {
            // grey out
            gameObject.GetComponent<Renderer>().material.color = originalColor * greyOutLightness;
        }
        else
        {
            // un-grey out
            gameObject.GetComponent<Renderer>().material.color = originalColor;
        }

        // move seleted object
        if (Globals.Instance.SelectedObject != null)
        {
            // move plant over dragging plane
            Plane plane = new Plane(Vector3.up, Vector3.up * yHeightDraggedObject); // dragging plane
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance; // the distance from the ray origin to the ray intersection of the plane
            if (plane.Raycast(ray, out distance))
            {
                Globals.Instance.SelectedObject.transform.position = ray.GetPoint(distance); // distance along the ray
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
            // (if we can afford it)
            if (Globals.Instance.SunScore >= gameObject.GetComponent<PlantVars>().plantPrice)
            {
                // create copy to select (as child of scene *root*)
                Globals.Instance.SelectedObject = (GameObject)Instantiate(gameObject, transform.position, transform.rotation);
                // disable selected plant
                DisableEnable.Disable(Globals.Instance.SelectedObject);
                // dont raycast dragged object
                Globals.Instance.SelectedObject.layer = 2; // Ignore Raycast Layer
            }
        }
        else // we have an object selected, but are clicking the toolbar
        {
            // unselect plant
            Destroy(Globals.Instance.SelectedObject);
            Globals.Instance.SelectedObject = null;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // remove tooltip
        // TODO
    }
}
