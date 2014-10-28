using UnityEngine;
using System.Collections;

public class CardData {
	public enum TYPE{
		SORD,
		BULLET,
		ITEM,
	};
	public string 	name;
	public int 		type;
	public int		id;
	public Texture	tex;
	public CardData(string _name,int _type,int _id,Texture _tex)
	{
		name 	= _name;
		type 	= _type;
		id  	= _id;
		tex 	= _tex;
	}
};

public class GameManager : MonoBehaviour {
	private static GameManager mInstance;
	//private static CardData[] CardManager = {{"test",0,1,Load<Texture>("image/mask")}};
	private static CardData[] CardManager = new CardData[]{
		new CardData("test",0,1,Resources.Load<Texture>("image/mask")),
	};
	
	private GameManager () { // Private Constructor
		
		Debug.Log("Create SampleSingleton GameObject instance.");
	}
	
	public static GameManager Instance {
		
		get {
			if( mInstance == null ) {
				GameObject go = GameObject.Find("GameManager");
				mInstance = go.AddComponent<GameManager>();
			}
			
			return mInstance;
		}
	}

	public CardData GetCard( string name )
	{
		int i = 0;
		while (CardManager[i] != null)
		{
			if ( CardManager[i].name == name )
			{
				return CardManager[0];
			}
			i++;
		}
		return null;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
