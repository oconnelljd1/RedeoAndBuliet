using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	[HideInInspector]public bool redCollectableGot = false, blueCollectableGot = false;

	private string[] levels = new string[8] {"Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level10"};

	void Awake () {
		MakeSingleton ();
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Backspace)){
			if (SceneController.instance.GetSkippable ()) {
				Death ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}

		if(redCollectableGot && blueCollectableGot){
			Debug.Log ("Wnner winner chicken Dinner");
			redCollectableGot = false;
			blueCollectableGot = false;
			SceneController.instance.LoadNextScene ();
		}
		for ( int i = 0; i < 9; ++i )
		{
			if ( Input.GetKeyDown( "" + (i) ) )
			{
				SceneManager.LoadScene (levels[i - 1]);
			}
		}

	}

	void MakeSingleton () {
		if (instance != null) {
			Destroy (gameObject);
		} 
		else {
			Application.targetFrameRate = 30;
			//Cursor.lockState = CursorLockMode.Locked;
			Screen.SetResolution(640, 480, true);
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void Death(){
		redCollectableGot = false;
		blueCollectableGot = false;
		Debug.Log ("Reloading");
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}




}
