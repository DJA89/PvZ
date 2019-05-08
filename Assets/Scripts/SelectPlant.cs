using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private float yHeightDraggedObject = 1;

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
        // TODO
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // select object (to be placed with a click)
        // TODO
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // remove tooltip
        // TODO
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // create copy to select (as child of scene *root*)
        Globals.Instance.SelectedObject = (GameObject)Instantiate(gameObject, transform.position, transform.rotation);
        // dont raycast dragged object
        Globals.Instance.SelectedObject.layer = 2; // Ignore Raycast Layer
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move plant over dragging plane
        Plane plane = new Plane(Vector3.up, Vector3.up * yHeightDraggedObject); // dragging plane
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        float distance; // the distance from the ray origin to the ray intersection of the plane
        if (plane.Raycast(ray, out distance))
        {
            Globals.Instance.SelectedObject.transform.position = ray.GetPoint(distance); // distance along the ray
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // we dropped the plant (drag&drop)
        // => remove dragged plant
        Destroy(Globals.Instance.SelectedObject);
        Globals.Instance.SelectedObject = null;
    }
}
