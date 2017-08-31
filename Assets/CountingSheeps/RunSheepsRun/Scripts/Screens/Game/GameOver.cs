using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{
    public class GameOver : MonoBehaviour
    {

        public Text scoreText;
        public Text pointsText;
        public Text XPText;

        /// <summary>
        /// TODO: Colocar uma contagem do score depois
        /// </summary>
        /// <param name="score"></param>
        public void ShowScore(int score)
        {
            scoreText.text = string.Format("{0:000}", score);
        }
    }
}