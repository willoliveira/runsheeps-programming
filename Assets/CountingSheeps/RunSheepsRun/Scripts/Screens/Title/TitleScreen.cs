using UnityEngine;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{
    public class TitleScreen : MonoBehaviour
    {

        public GameObject mCamera;

        public void ScreenOpen()
        {
            //seta e tela atual
            GameManager.CurrentScreen = Screens.Title;
        }

        public void ScreenExit()
        {
            //gameObject.SetActive(false);
        }

        public void OnInitGame()
        {
            //Inicia a animação da camera
            //mCamera.GetComponent<Animator>().SetTrigger("StartGame");
        }
    }
}