using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private bool flipping = false;
	[SerializeField]private float moveSpeed = 1;

	[SerializeField] private bool canFlip;

	public LayerMask layerMask;

	void OnEnable(){
		EventManager.StartListening ("SwithcGravity", SwitchGravity);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!flipping) {
			transform.Translate (transform.right * -Time.deltaTime * moveSpeed);
		}
		Vector2 point = new Vector2 (transform.position.x - (0.32f * transform.localScale.x), transform.position.y - (0.32f * transform.localScale.y));
		Collider2D[] groundCheck = Physics2D.OverlapCircleAll (point, 0.02f);
		if (groundCheck.Length == 0 && !flipping) {
			Vector3 tempS = transform.localScale;
			tempS.x *= -1;
			transform.localScale = tempS;
		}
		point = new Vector2 (transform.position.x - (0.3f * transform.localScale.x), transform.position.y);
		Collider2D[] wallCheck = Physics2D.OverlapBoxAll (point, new Vector2 (0.05f, 0.32f), 0, layerMask);
		if(wallCheck.Length > 0 && !flipping){
			Debug.Log (wallCheck[0].name);
			Vector3 tempS = transform.localScale;
			tempS.x *= -1;
			transform.localScale = tempS;
		}
	}

	private void SwitchGravity(){
		if (canFlip) {
			flipping = true;
		}
	}

	public void SetFlipping(bool _flipping){
		flipping = _flipping;
	}

}
