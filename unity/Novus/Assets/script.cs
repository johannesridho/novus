using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sprite backSprite = Resources.Load<Sprite>("resources/books.png");
        GameObject obj = new GameObject("book");
        SpriteRenderer rend = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        obj.transform.position = Vector3.zero;
        rend.sprite = backSprite;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
