using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectPlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler
{
    private float yHeightDraggedObject = 1;

    //private Renderer cellRenderer;
    //private Color cellColor;

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
        //// create copy to select
        //SelectionManager.Instance.Selected = gameObject;
        //print("selected: " + gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // remove tooltip
        // TODO

        //// if we have a shadow
        //if (plantShadow != null)
        //{
        //    // remove shadow
        //    Destroy(plantShadow);
        //    plantShadow = null;
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        // create copy to select
        //SelectionManager.Instance.Selected =  gameObject;
        SelectionManager.Instance.Selected = (GameObject)Instantiate(gameObject, transform.position, transform.rotation);
        // dont raycast dragged object
        SelectionManager.Instance.Selected.layer = 2; // Ignore Raycast Layer

        //print("started dragging: " + gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // move plant over dragging plane
        Plane plane = new Plane(Vector3.up, Vector3.up * yHeightDraggedObject); // dragging plane
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        float distance; // the distance from the ray origin to the ray intersection of the plane
        if (plane.Raycast(ray, out distance))
        {
            SelectionManager.Instance.Selected.transform.position = ray.GetPoint(distance); // distance along the ray
        }
    }
}
