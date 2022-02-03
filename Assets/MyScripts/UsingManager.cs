using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingManager : MonoBehaviour
{
    [SerializeField]
    private List<UsingParentScript> list;

    [ContextMenu("Start test")]
    private void StartUsingTest()
    {
        Debug.Log("The test is running");
        foreach (var element in list)
        {
            element.Use();
        }
    }
}
