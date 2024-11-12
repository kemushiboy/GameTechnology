using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject player;

    public ScoreCount scoreCount;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if( other.gameObject == player ) 
        {
            Destroy(gameObject);
        
            scoreCount.CountUp();

            audioSource.Play();
        }


	}

}
