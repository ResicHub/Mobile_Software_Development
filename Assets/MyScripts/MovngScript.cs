using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovngScript : UsingParentScript
{
    private Transform myTransform;

    [SerializeField]
    private Transform target;
    [SerializeField]
    [Range(0.1f, 10f)]
    private float movingSpeed = 1f;
    private bool isMoving = false;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    public override void Use()
    {
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector3 direction = target.position - myTransform.position;
            if (direction.magnitude > 0.01f)
            {
                myTransform.forward = direction;
                myTransform.position += direction.normalized * movingSpeed * Time.deltaTime;
            }
            else
            {
                isMoving = false;
            }
        }
    }
}
