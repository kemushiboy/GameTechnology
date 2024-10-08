using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {

            float x = Random.Range(-10f, 10f);

            float y = 0.5f;

            float z = Random.Range(-10f, 10f);

            Vector3 position = new Vector3(x, y, z);

            Instantiate(prefab, position, Quaternion.Euler(0f, 0f, 0f));

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
