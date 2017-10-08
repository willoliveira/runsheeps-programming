using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using DoozyUI;

namespace CountingSheeps.RunSheepsRun
{
    public class ReturnGame : MonoBehaviour
    {

        private const int COUNT_DEFAULT = 3;

        public Text countText;

		public float countTime;
        public int count = 3;

		public void onPopUpOpen()
		{
			Debug.Log("onPopUpOpen");
			StartCoroutine(StartCounter());
		}

		public void onPopUpExit()
		{
			Debug.Log("onPopUpExit");
		}

		public IEnumerator StartCounter()
		{
			yield return StartCoroutine(CountReturn());

			gameObject.GetComponent<UIElement>().Hide(false);
		}

		public IEnumerator CountReturn()
        {
            count = COUNT_DEFAULT;
            countText.text = string.Format("{0}", count);
            while (count > 0)
            {
				Debug.Log(count);
                //espera um segundo
                yield return new WaitForSeconds(1);
                //diminui 1
                count -= 1;
                //escreve na tela
                countText.text = string.Format("{0}", count);
            }
        }
    }
}