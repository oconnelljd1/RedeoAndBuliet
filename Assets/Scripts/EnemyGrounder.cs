using UnityEngine;
using System.Collections;

public class EnemyGrounder : MonoBehaviour {

	[SerializeField]private string[] tags;

	private EnemyAI nmeAI;

	// Use this for initialization
	void Start () {
		nmeAI = GetComponentInParent<EnemyAI> ();
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
		if(stop){
			nmeAI.SetFlipping (false);;
		}
	}
}
