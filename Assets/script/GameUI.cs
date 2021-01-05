using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUI : MonoBehaviour
{
    public Text scoreText;
    public GameObject GameoverPanel;
    public void SetscoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }
    public void ShowGameoverPanel(bool Unhide)
    {
        if(GameoverPanel)
        {
            GameoverPanel.SetActive(Unhide);
        }
    }


}
