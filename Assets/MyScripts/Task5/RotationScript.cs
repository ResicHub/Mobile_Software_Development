using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : UsingParentScript
{
    private Transform myTransform;
    private bool isHighlighted = false;
    private Outline outlineScript;

    [SerializeField]
    private Transform target;
    [SerializeField]
    [Range(10, 100)]
    private float rotationSpeed = 10;
    private bool isRotating = false;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
        outlineScript = GetComponent<Outline>();
    }

    [ContextMenu("Start test")]
    public override void Use()
    {
        isRotating = true;
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
        if (isRotating)
        {
            Quaternion direction = Quaternion.LookRotation(target.position - myTransform.position);
            if (myTransform.rotation != direction)
            {
                myTransform.rotation = Quaternion.RotateTowards(myTransform.rotation, direction, rotationSpeed * Time.deltaTime);
            }
            else
            {
                isRotating = false;
                myTransform.rotation = direction;
            }
        }
    }
}
