using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyingScript : UsingParentScript
{
    private Transform myTransform;
    private bool isHighlighted = false;
    private Outline outlineScript;

    [SerializeField]
    private Transform copyPrefab;

    [SerializeField]
    [Range(1, 100)]
    private int copyCount = 1;
    [SerializeField]
    [Range(1f, 10f)]
    private float interval = 1f;

    private void Start()
    {
        myTransform = GetComponent<Transform>();
        outlineScript = GetComponent<Outline>();
    }

    [ContextMenu("Start test")]
    public override void Use()
    {
        for (int i = 0; i < myTransform.childCount; i++)
        {
            Destroy(myTransform.GetChild(i).gameObject);
        }

        for (int i = 1; i < copyCount; i++)
        {
            Transform copy = Instantiate(copyPrefab, myTransform.position + myTransform.forward * i * interval, myTransform.rotation).parent = myTransform;
            copy.parent = myTransform;
        }
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
}
