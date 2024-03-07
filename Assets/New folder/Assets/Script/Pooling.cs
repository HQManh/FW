using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    [SerializeField] Coloring poolObject;
    [SerializeField] int amount;
    List<GameObject> pooledObject = new();
    int currentNum = 0;


    private void Awake()
    {
        PoolObject();
    }

    void PoolObject()
    {
        for(int i=0; i< amount; i++)
        {
            var t = Instantiate(poolObject, transform);
            t.SetNum(currentNum);
            currentNum++;
            pooledObject.Add(t.gameObject);
        }
    }



}
