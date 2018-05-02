using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentTextBehaviour : MonoBehaviour {
	// Use this for initialization
	private TextMesh contentText;
	private int counter;
	private static string[] CONTENTS = {"Connect with friends and the\nworld around you on Facebook.", 
		"Welcome to F8!", "Had a great experience at F8!", "Greatest hackathon so far", "Cool!"};

	void Start () {
		contentText = GetComponent<TextMesh>();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.RightArrow) && counter < CONTENTS.Length - 1)
		{
			counter++;
			Color newColor = new Color(1, 1, 1, 0);
			transform.GetComponent<Renderer>().material.color = newColor;
			contentText.text = CONTENTS[counter];
			StartCoroutine(FadeTo(1.0f, 2.0f));
		}

		if (Input.GetKeyUp(KeyCode.LeftArrow) && counter > 0)
		{
			counter--;
			Color newColor = new Color(1, 1, 1, 0);
			transform.GetComponent<Renderer>().material.color = newColor;
			contentText.text = CONTENTS[counter];
			StartCoroutine(FadeTo(1.0f, 1.0f));
		}
	}

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = transform.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            transform.GetComponent<Renderer>().material.color = newColor;
            yield return null;
        }
    }
}
