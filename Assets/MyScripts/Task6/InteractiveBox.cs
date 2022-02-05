using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private InteractiveBox next;

    private Transform myTransform;
    private LineRenderer myLineRenderer;
    private const float rayDistance = 100;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
        myLineRenderer = GetComponent<LineRenderer>();
    }

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    public void ActivateModule()
    {
        GetComponentInChildren<UsingParentScript>().Use();
    }

    private void FixedUpdate()
    {
        if (next)
        {
            if (Physics.Raycast(myTransform.position, next.transform.position - myTransform.position, out RaycastHit hit, rayDistance))
            {
                Debug.DrawLine(myTransform.position, hit.point, Color.red, 0.3f);
                DrawLine(hit);
                if (hit.collider.tag == "Obstacle")
                {
                    hit.transform.GetComponent<ObstacleItem>().onDestroyObstacle.AddListener(() => ActivateModule());
                    hit.transform.GetComponent<ObstacleItem>().GetDamage(Time.deltaTime);
                }
            }
        }
        else
        {
            myLineRenderer.positionCount = 0;
        }
    }

    private void DrawLine(RaycastHit hit)
    {
        if (myLineRenderer.positionCount != 2)
        {
            myLineRenderer.positionCount = 2;
        }
        myLineRenderer.SetPosition(0, myTransform.position);
        myLineRenderer.SetPosition(1, hit.point);
    }
}
