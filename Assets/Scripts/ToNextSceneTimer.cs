using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToNextSceneTimer : MonoBehaviour {

	public string nextLevel;
	public int timer;

	void Start () {
	
	}

	void Update () {
		if (timer > 0) {
			timer--;
		} 
		else {
			GameManager.instance.blueCollectableGot = false;
			GameManager.instance.redCollectableGot = false;
			SceneManager.LoadScene (nextLevel);
		}
	}
}
