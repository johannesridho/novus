using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KettleTextBehaviour : MonoBehaviour {
	// Use this for initialization
	private TextMesh contentText;
	private int counter;
	private static string[] CONTENTS = {"What a delicious snack", "This makes me fat", "What a snack!"};

	// Awake function from Unity's MonoBehavior
	void Awake ()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(InitCallback, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			FB.ActivateApp();
		}
	}

	void Start () {
		contentText = GameObject.Find("KettleText").GetComponent<TextMesh>();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.RightArrow) && counter < CONTENTS.Length - 1)
		{
			var perms = new List<string>(){"public_profile", "email"};
//			FB.LogInWithReadPermissions(perms, AuthCallback);

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

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			// Signal an app activation App Event
			FB.ActivateApp();
			// Continue with Facebook SDK
			// ...
		} else {
			Debug.Log("Failed to Initialize the Facebook SDK");
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		} else {
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	private void AuthCallback (ILoginResult result) {
		if (FB.IsLoggedIn) {
			// AccessToken class will have session details
			var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;
			// Print current access token's User ID
			Debug.Log(aToken.UserId);
			// Print current access token's granted permissions
			foreach (string perm in aToken.Permissions) {
				Debug.Log(perm);
			}
		} else {
			Debug.Log("User cancelled login");
		}
	}
}
