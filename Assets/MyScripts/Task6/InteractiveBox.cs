using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private InteractiveBox next;

    private Transform myTransform;
    private const float rayDistance = 100;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    private void FixedUpdate()
    {
        if (next)
        {
            if (Physics.Raycast(myTransform.position, next.transform.position - myTransform.position, out RaycastHit hit, rayDistance))
            {
                Debug.DrawLine(myTransform.position, hit.point, Color.red, 0.3f);
                if (hit.collider.tag == "Obstacle")
                {
                    hit.transform.GetComponent<ObstacleItem>().GetDamage(Time.deltaTime);
                }
            }
        }
    }
}
