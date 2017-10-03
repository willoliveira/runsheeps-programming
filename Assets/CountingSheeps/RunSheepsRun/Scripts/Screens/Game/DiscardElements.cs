using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CountingSheeps.RunSheepsRun
{

    public class DiscardElements : MonoBehaviour
    {
		private void Start()
		{
			
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			Debug.Log(collision.gameObject.tag);
		}
		/// <summary>
		/// Colider do player
		/// </summary>
		/// <param name="coll"></param>
		private void OnCollisionExit2D(Collision2D collision)
		{
			Debug.Log(collision.gameObject.tag);
			if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "ElementGame")
			{
				Destroy(collision.gameObject);
			}
		}
	}
}