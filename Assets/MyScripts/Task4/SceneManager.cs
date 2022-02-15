using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private void Awake()
    {
        Application.LoadLevelAdditive("Part2");
        Application.LoadLevelAdditive("Part4");
        Application.LoadLevelAdditive("Part3");
    }
}
