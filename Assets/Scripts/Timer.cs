using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    public GameObject gameOver;

    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 30;

        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;

        if(time < 0)
        {
            gameOver.SetActive(true);

            textMesh.text = "0";
        }
        else
        {
			textMesh.text = time.ToString("0");
		}


    }
}
