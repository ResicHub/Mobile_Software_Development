using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovngScript : UsingParentScript
{
    private Transform myTransform;
    private bool isHighlighted = false;
    private Outline outlineScript;

    [SerializeField]
    private Transform target;
    [SerializeField]
    [Range(0.1f, 10f)]
    private float movingSpeed = 1f;
    private bool isMoving = false;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
        outlineScript = GetComponent<Outline>();
    }

    [ContextMenu("Start test")]
    public override void Use()
    {
        isMoving = true;
    }
    public override void Outline()
    {
        if (isHighlighted)
        {
            outlineScript.OutlineWidth = 0f;
            isHighlighted = false;
        }
        else
        {
            outlineScript.OutlineWidth = 10f;
            isHighlighted = true;
        }
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
                myTransform.position = target.position;
            }
        }
    }
}
