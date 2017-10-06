using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CountingSheeps.RunSheepsRun
{
    public class StoreScreen : MonoBehaviour
    {
		private StoreMain storeMain;

        private int currentChar = 0;

		private void Start()
		{

		}
        /// <summary>
        /// 
        /// </summary>
        public void ScreenOpen()
        {
            //seta e tela atual
            GameManager.CurrentScreen = Screens.Store;

			storeMain = GetComponent<StoreMain>();
			storeMain.Init();
		}
		/// <summary>
		/// 
		/// </summary>
		public void ScreenExit()
        {
			storeMain.Destroy();
		}
		/// <summary>


	}
}