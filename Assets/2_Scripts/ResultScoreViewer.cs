using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScoreViewer : MonoBehaviour
{
    TextMeshProUGUI textScore;
    void Start()
    {
        textScore = GetComponent<TextMeshProUGUI>();
        textScore.text = "Result Score " + PlayerPrefs.GetInt("Score");
    }

}
