using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBehaviour : MonoBehaviour {
	public float minSwipeDistY;

	public float minSwipeDistX;

	private Vector2 startPos;

	private TextMesh contentText;

	// Use this for initialization
	void Start () {
		contentText = GameObject.Find("FbText").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			if(Input.GetTouch(0).deltaPosition.x > 0){
				contentText.text = "right";
			}

			if(Input.GetTouch(0).deltaPosition.x < 0){
				contentText.text = "left";
			}
		}
	}
}
