using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject character;
    void Start()
    {
        for(int i = 0; i < 100;  i++)
        {
           
            character = Instantiate(character, new Vector3(Random.Range(-50,50),5, Random.Range(-50, 50)),Quaternion.Euler(0,0,0));
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
