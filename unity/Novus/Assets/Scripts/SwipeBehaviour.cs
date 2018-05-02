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

			Touch touch = Input.touches[0];


			switch (touch.phase)
			{

			case TouchPhase.Began:

				startPos = touch.position;

				break;



			case TouchPhase.Ended:

				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) {

					float swipeVerticalValue = Mathf.Sign (touch.position.y - startPos.y);

					if (swipeVerticalValue > 0) {
						Debug.Log ("atas");
						//Jump ();
					} else if (swipeVerticalValue < 0) {
						Debug.Log ("bawah");
						//Shrink ();
					}
				}

				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;

				if (swipeDistHorizontal > minSwipeDistX) {

					float swipeHorizontalValue = Mathf.Sign (touch.position.x - startPos.x);

					if (swipeHorizontalValue > 0) {
						contentText.text = "kanan";
						// MoveRight ();
					} else if (swipeHorizontalValue < 0) {
						contentText.text = "kiri";
						//MoveLeft ();
					}
				}
				break;
			}
	}
}
}
