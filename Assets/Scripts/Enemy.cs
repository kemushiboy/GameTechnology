using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {


    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == player)
        {
            Destroy(other.gameObject);

            gameOver.SetActive(true);

        }


	}

}
