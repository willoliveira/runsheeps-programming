using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace CountingSheeps.RunSheepsRun
{
    public class ReturnGame : MonoBehaviour
    {

        private const int COUNT_DEFAULT = 3;

        public Text countText;
        public int count = 3;

        public IEnumerator CountReturn()
        {
            count = COUNT_DEFAULT;
            countText.text = string.Format("{0}", count);
            while (count > 0)
            {
                //espera um segundo
                yield return new WaitForSeconds(1);
                //diminui 1
                count -= 1;
                //escreve na tela
                countText.text = string.Format("{0}", count);
            }
            //yield return null;
        }
    }
}