using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {
	public float incX = 3;
	public float incY = 3;
	//public AudioClip btn_se1;
	public string nextScene;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		//audio.PlayOneShot(btn_se1);
		Rect tmp = gameObject.guiTexture.pixelInset;
		tmp.x += incX;
		tmp.y -= incY;
		gameObject.guiTexture.pixelInset = tmp;
		
		Debug.Log ("Btn pressed!!! : " + gameObject.name);
	}
	
	void OnMouseUp(){
		if (nextScene.Equals ("Quit")) {
			Application.Quit();
		} else {
			//Application.LoadLevel (nextScene);
			Rect tmp = gameObject.guiTexture.pixelInset;
			tmp.x -= incX;
			tmp.y += incY;
			gameObject.guiTexture.pixelInset = tmp;
		}
	}
}
