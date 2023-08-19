using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
   public TextMeshProUGUI Points;
   private int score;

   private void Start()
   {
    score = 0;
    NewGame();
   }

   private void NewGame()
   {
    score = 0;
    Points.text = score.ToString();
   }

   public void IncreaseScore()
   {
    score++;
    Points.text = score.ToString() ?? "0";
   }
}
