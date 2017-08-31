﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CountingSheeps.RunSheepsRun
{
    public class QuitGame : MonoBehaviour
    {

        #region PUBLIC VARS
        public GameObject QuitScreen;
        #endregion

        #region PRIVATE VARS
        private bool QuitOpen;
        #endregion

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!QuitScreen.activeSelf)
                {
                    GameManager.Pause = true;

                    QuitScreen.SetActive(true);
                }
                else
                {
                    Quit();
                }
            }
        }

        #region PUBLIC METHODS
        /// <summary>
        /// 
        /// </summary>
        public void OnButtonOk()
        {
            Quit();
        }
        /// <summary>
        /// 
        /// </summary>
        public void OnButtonCancel()
        {
            GameManager.Pause = false;

            QuitScreen.SetActive(false);
        }
        #endregion

        #region PRIVATE METHODS
        /// <summary>
        /// 
        /// </summary>
        private void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
        }
        #endregion

    }
}