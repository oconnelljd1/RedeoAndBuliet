using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	[SerializeField]private GameObject player1, player2;
	private float distanceScaleX = 10, distanceScaleY = 10;
	private float maxDistanceX = 12, maxDistanceY = 8;

	private Camera camera;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		float distanceX = Mathf.Abs (player2.transform.position.x - player1.transform.position.x);
		float distanceY = Mathf.Abs (player2.transform.position.y - player1.transform.position.y);
		if (distanceX * 0.75f > distanceY) {
			if (distanceX > maxDistanceX) {
				camera.orthographicSize = distanceX / maxDistanceX * 5;
			}
		} else {
			if (distanceY > maxDistanceY) {
				camera.orthographicSize = distanceY / maxDistanceY * 5;
			}
		}
		Vector3 tempT = transform.position;
		tempT.x = (player1.transform.position.x + player2.transform.position.x) / 2;
		tempT.y = (player1.transform.position.y + player2.transform.position.y) /2;
		transform.position = tempT;
	}
}
