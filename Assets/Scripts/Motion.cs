using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = x + 0.01f;

        transform.localScale = transform.localScale + new Vector3(0.01f, 0.01f, 0.01f) * Mathf.Sin(x);
    }
}
