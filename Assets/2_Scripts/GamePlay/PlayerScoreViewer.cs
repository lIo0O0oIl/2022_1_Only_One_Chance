using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField] Player player;
    TextMeshProUGUI textScore;

    private void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textScore.text = "Score : " + player.Score;     // 플레이어 스크립트의 스코어로 계속해서 변경중
    }
}
