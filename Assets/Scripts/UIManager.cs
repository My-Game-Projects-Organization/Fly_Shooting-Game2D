using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;

    public GameObject gameoverPanel;

    public void setScoreText(string value)
    {
        if (scoreText)
        {
            scoreText.text = value;
        }
    }

    public void ShowGameOverPanel(bool state)
    {
        gameoverPanel.SetActive(state);
    }
}
