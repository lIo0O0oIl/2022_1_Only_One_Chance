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
        textScore.text = "Score : " + PlayerPrefs.GetInt("Score");      // 프리텝으로 저장해준 거 가져와서 표시해주기
    }

}
