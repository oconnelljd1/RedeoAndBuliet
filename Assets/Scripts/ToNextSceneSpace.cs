using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToNextSceneSpace : MonoBehaviour {

	public string nextLevel;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene (nextLevel);
		}
	}
}
