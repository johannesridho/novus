using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FbTextBehaviour : MonoBehaviour {
	// Use this for initialization
	private TextMesh contentText;
	private int counter;
	private static string[] CONTENTS = {"Connect with friends and the\nworld around you on Facebook.", 
		"Welcome to F8!", "Had a great experience at F8!", "Greatest hackathon so far", "Cool!"};

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
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://novus-9e2c2.firebaseio.com/");
        // firebase::Future<firebase::database::DataSnapshot> result = dbRef.GetReference("Leaders").GetValue();
        string r = FirebaseDatabase.DefaultInstance.GetReference("fb").ToString();
        

        contentText = GameObject.Find("FbText").GetComponent<TextMesh>();
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyUp(KeyCode.RightArrow) || Input.GetMouseButtonUp(0)) && counter < CONTENTS.Length - 1)
		{
			if (counter == 0) {
				var perms = new List<string>(){"public_profile", "email"};
				FB.LogInWithReadPermissions(perms, AuthCallback);
			}

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
