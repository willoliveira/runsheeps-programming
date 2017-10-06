using UnityEngine;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{
    public class TitleScreen : MonoBehaviour
    {
		private void Start()
		{
			
		}

		public void ScreenOpen()
        {
            //seta e tela atual
            GameManager.CurrentScreen = Screens.Title;
        }

        public void ScreenExit()
        {

        }
    }
}