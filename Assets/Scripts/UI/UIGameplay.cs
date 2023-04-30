using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateScoreText()
    {
        if(GameManager.instance.players.Count > 0)
        {
            scoreText.text = GameManager.instance.players[0].score.ToString();
        }
    }
}
