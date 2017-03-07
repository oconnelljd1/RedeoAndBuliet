using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public static SceneController instance;

	[SerializeField] private bool skippable = true;
	[SerializeField] private string nextScene;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool GetSkippable(){
		return skippable;
	}

	public void LoadNextScene(){
		SceneManager.LoadScene(nextScene);
	}
}
