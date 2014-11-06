using UnityEngine;
using System.Collections;

public class CardData {
	public enum TYPE{
		SORD,
		BULLET,
		ITEM,
	};
	public string 	name;
	public TYPE 	type;
	public int		id;
	public float 	rigor;
	public Texture	tex;

	public CardData(string _name,TYPE _type,int _id,float _rigor,Texture _tex)
	{
		name 	= _name;
		type 	= _type;
		id  	= _id;
		rigor = _rigor;
		tex 	= _tex;
	}
};

public class GameManager {
	private static GameManager mInstance;

	private static CardData[] CardManager = new CardData[]{
		new CardData("sord",CardData.TYPE.SORD,0,1.0f,(Texture)Resources.Load<Texture>("image/sord")),
		new CardData("bom" ,CardData.TYPE.BULLET,0,1.0f,(Texture)Resources.Load<Texture>("image/bom")),
		new CardData("life",CardData.TYPE.ITEM,0,1.0f,(Texture)Resources.Load<Texture>("image/life")),
		new CardData("long",CardData.TYPE.SORD,1,1.0f,(Texture)Resources.Load<Texture>("image/long")),
		new CardData("wide",CardData.TYPE.SORD,2,1.0f,(Texture)Resources.Load<Texture>("image/wide")),
	};
	
	private GameManager () { // Private Constructor
		
		Debug.Log("Create SampleSingleton GameObject instance.");
	}
	
	public static GameManager Instance {
		
		get {
			if( mInstance == null ) {
				mInstance = new GameManager();
			}
			
			return mInstance;
		}
	}

	public CardData GetCard( int id )
	{
		if (CardManager[id] != null) {
			return CardManager[id];
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
