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
	public int		effect;
	public float	wait;

	public CardData(string _name,TYPE _type,int _id,float _rigor,float _wait,Texture _tex,int _effect)
	{
		name 	= _name;
		type 	= _type;
		id  	= _id;
		rigor 	= _rigor;
		tex 	= _tex;
		effect 	= _effect;
		wait 	= _wait;
	}
};

public class GameManager {
	private static GameManager mInstance;
	private static effectManager effectInstance = new effectManager();

	private static CardData[] CardManager = new CardData[]{
		new CardData("sord",CardData.TYPE.SORD,0,1.0f,3.0f,(Texture)Resources.Load<Texture>("image/sord"),effectInstance.setEffect("prefab/slashPrefab")),
		new CardData("bom" ,CardData.TYPE.BULLET,1,1.0f,10.0f,(Texture)Resources.Load<Texture>("image/bom"),effectInstance.setEffect("prefab/bom")),
		new CardData("beam",CardData.TYPE.BULLET,0,1.0f,5.0f,(Texture)Resources.Load<Texture>("image/life"),effectInstance.setEffect("prefab/BilletPrefab")),
		new CardData("long",CardData.TYPE.SORD,1,1.0f,10.0f,(Texture)Resources.Load<Texture>("image/long"),effectInstance.setEffect("prefab/skillAttack")),
		new CardData("wide",CardData.TYPE.SORD,2,1.0f,12.0f,(Texture)Resources.Load<Texture>("image/wide"),effectInstance.setEffect("prefab/skillAttack")),
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

	public effectManager getEffectInstance() {
		return effectInstance;
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
