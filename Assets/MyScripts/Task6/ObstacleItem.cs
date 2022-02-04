using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    private Material myMaterial;
    [SerializeField]
    private float currentValue = 1;
    [SerializeField]
    private UnityEvent onDestroyObstacle;

    private void Start()
    {
        myMaterial = gameObject.GetComponent<MeshRenderer>().material;
        onDestroyObstacle.AddListener(() => Destroy(gameObject));
    }

    public void GetDamage(float value)
    {
        currentValue -= value;
        myMaterial.color = new Color(1, 1 * currentValue, 1 * currentValue);
        if (currentValue <= 0)
        {
            onDestroyObstacle.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetDamage(0.1f);
        }
    }
}
