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
            Color newColor = new Color(1, 1, 1, 0);
            transform.GetComponent<Renderer>().material.color = newColor;
            contentText.text = "Welcome to F8!";
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
