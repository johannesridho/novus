using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentTextBehaviour : MonoBehaviour {
	// Use this for initialization
	private TextMesh contentText;

	void Start () {
		contentText = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			contentText.text = "Welcome to F8!";
		}
	}
}
