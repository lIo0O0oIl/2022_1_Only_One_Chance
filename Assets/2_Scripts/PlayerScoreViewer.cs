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
        textScore.text = "Score : " + player.Score;
    }
}
