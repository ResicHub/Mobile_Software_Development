using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteractiveRaycast : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private List<GameObject> prefabList;
    [SerializeField]
    private GameObject selectedInteractiveBox = null;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                if (hit.collider.tag == "InteractivePlane")
                {
                    Instantiate(prefabList[Random.Range(0, prefabList.Count)], hit.point + Vector3.up * 0.5f, Quaternion.identity);
                }
                else if (hit.collider.GetComponentInParent<InteractiveBox>())
                {
                    if (selectedInteractiveBox != null)
                    {
                        if (!Equals(selectedInteractiveBox, hit.collider.gameObject))
                        {
                            selectedInteractiveBox.GetComponentInParent<InteractiveBox>().AddNext(hit.collider.gameObject.GetComponentInParent<InteractiveBox>());
                        }
                        selectedInteractiveBox.GetComponent<UsingParentScript>().Outline();
                        selectedInteractiveBox = null;
                    }
                    else
                    {
                        selectedInteractiveBox = hit.collider.gameObject;
                        selectedInteractiveBox.GetComponent<UsingParentScript>().Outline();
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                if (hit.collider.GetComponentInParent<InteractiveBox>())
                {
                    Destroy(hit.transform.parent.gameObject);
                }
            }
        }
    }
}
