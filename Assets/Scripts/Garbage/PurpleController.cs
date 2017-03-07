using UnityEngine;
using System.Collections;

public class PurpleController : MonoBehaviour {

	void OnEnable(){
		EventManager.StartListening ("SwithcGravity", SwitchGravity);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	private void SwitchGravity(){
	}
}
