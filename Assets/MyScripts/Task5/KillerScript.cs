using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerScript : UsingParentScript
{
    private Transform myTransform;
    private bool isHighlighted = false;
    private Outline outlineScript;

    [SerializeField]
    private Transform target;
    private bool isWorking = false;
    private float destructionSpeed = 0.5f;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
        outlineScript = GetComponent<Outline>();
    }

    [ContextMenu("Start test")]
    public override void Use()
    {
        isWorking = true;
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
        if (isWorking)
        {
            if (target.childCount > 0)
            {
                for (int i = 0; i < target.childCount; i++)
                {
                    target.GetChild(i).transform.localScale -= Vector3.one * destructionSpeed * Time.deltaTime;
                    if (target.GetChild(i).transform.localScale.x < 0)
                    {
                        Destroy(target.GetChild(i).gameObject);
                    }
                }
            }
            else
            {
                isWorking = false;
            }
        }
    }
}
