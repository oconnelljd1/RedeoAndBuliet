using UnityEngine;
using System.Collections;

public class CollectableController : MonoBehaviour {

	[SerializeField]private string playerTag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D trigger){
		if (trigger.CompareTag (playerTag)) {
			if(playerTag == "Player1"){
				GameManager.instance.redCollectableGot = true;
			}else if(playerTag == "Player2"){
				GameManager.instance.blueCollectableGot = true;
			}
			Object.Destroy (gameObject);
		}
	}

}
