using Firebase;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebase : MonoBehaviour
{
    void Start()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://novus-9e2c2.firebaseio.com/");
    }
}