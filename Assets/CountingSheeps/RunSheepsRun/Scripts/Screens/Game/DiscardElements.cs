using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{

    public class DiscardElements : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "ElementGame")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}