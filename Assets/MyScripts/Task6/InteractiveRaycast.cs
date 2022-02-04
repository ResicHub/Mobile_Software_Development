using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteractiveRaycast : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private GameObject prefab;

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
                    Instantiate(prefab, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
