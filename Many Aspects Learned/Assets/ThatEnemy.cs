using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThatEnemy : MonoBehaviour {


		private bool dirRight = true;
		public float speed = 2.0f;

		void Update () {
			if (dirRight)
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			else
				transform.Translate (-Vector2.right * speed * Time.deltaTime);

			if(transform.position.x >= 2.0f) {
				dirRight = false;
			}

			if(transform.position.x <= -2.0f) {
				dirRight = true;
			}
		}

	}
