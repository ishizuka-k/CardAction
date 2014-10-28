using UnityEngine;
using System.Collections;

public class TextureManager : MonoBehaviour {
	private static TextureManager mInstance;
	
	private TextureManager () { // Private Constructor
		
		Debug.Log("Create SampleSingleton GameObject instance.");
	}
	
	public static TextureManager Instance {
		
		get {
			
			if( mInstance == null ) {
				
				GameObject go = new GameObject("TextureManager");
				mInstance = go.AddComponent<TextureManager>();
			}
			
			return mInstance;
		}
	}

	public Texture[] TexBox;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
