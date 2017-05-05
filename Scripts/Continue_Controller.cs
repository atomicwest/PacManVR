using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this has not been implemented yet

public class Continue_Controller : MonoBehaviour {

	public static bool waitRestart = false;

	private int cont_count = 10;

	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}

	IEnumerator Cont_Restart() {

		while(cont_count > 0) {

			if (Mathf.Abs(Input.acceleration.x) > 2 || Mathf.Abs(Input.acceleration.z) > 2) {
				Application.Quit ();
			}

			text.text = "Shake head to Exit \n or wait to continue: \n " + cont_count;

			yield return new WaitForSecondsRealtime (1);
			cont_count -= 1;
		}

		SceneManager.LoadScene (0);
		//yield break;
	}

	// Update is called once per frame
	void Update () {
		if (waitRestart)
		{
			gameObject.SetActive (true);
			//detect accelerometer input, then restart game
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			StartCoroutine(Cont_Restart());


			//SceneManager.LoadScene(0);
		}


	}
}
