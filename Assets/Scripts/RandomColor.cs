using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
       Material material = GetComponent<Renderer>().material;

        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);

        Color color = new Color(r, g, b);

        material.SetColor("Color", color);

	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
