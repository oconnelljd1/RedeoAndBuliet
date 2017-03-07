using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	[SerializeField]private string[] tags;

	bool switched = false;

	[SerializeField]private GameObject[] doors;
	[SerializeField]private Sprite sprit;

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

	void OnTriggerEnter2D(Collider2D trigger){
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
			spritR.sprite = sprit;
			foreach (GameObject door in doors) {
				door.GetComponent<DoorController> ().Open ();
			}
		}
	}

}
