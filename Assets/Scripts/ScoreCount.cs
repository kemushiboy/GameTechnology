using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI textMesh;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = score.ToString();
    }

    public void CountUp()
    {
        score += 1;
    }
}
