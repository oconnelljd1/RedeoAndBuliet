using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	[SerializeField]private string[] tags;

	[SerializeField]private GameObject[] doors;

	bool switched = false;

	[SerializeField] private Sprite sprit1, sprit2;

	private SpriteRenderer spritR;


	private AudioSource myAudio;
	[SerializeField]private AudioClip switchClip;

	// Use this for initialization
	void Start () {
		spritR = GetComponent<SpriteRenderer> ();
		myAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D trigger){
		bool stop = false;
		for(int i = 0; i < tags.Length; i ++){
			if(trigger.CompareTag(tags[i])){
				stop = true;
				break;
			}
		}
		if (stop) {
			if(!switched){
				myAudio.clip = switchClip;
				myAudio.loop = false;
				myAudio.Play ();
			}
			switched = true;
			spritR.sprite = sprit2;
			foreach (GameObject door in doors) {
				door.GetComponent<DoorController> ().Open ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D trigger){
		switched = false;
		spritR.sprite = sprit1;
		foreach (GameObject door in doors) {
			door.GetComponent<DoorController> ().Close ();
		}
	}
}
