using UnityEngine;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{
    public class RankingScreen : MonoBehaviour
    {

        // Use this for initialization
        private void Start()
        {

        }

        public void ScreenOpen()
        {
            //seta e tela atual
            GameManager.CurrentScreen = Screens.Store;
        }

        public void ScreenExit()
        {

        }
    }
}