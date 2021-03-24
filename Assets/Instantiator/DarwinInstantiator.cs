using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarwinInstantiator : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        for (int i = 0; i < 3; i++)
            Instantiate(prefab, new Vector3(Random.Range(-10.0f,10.0f), Random.Range(-10.0f, 10.0f), 0), Quaternion.identity);
    }
}
