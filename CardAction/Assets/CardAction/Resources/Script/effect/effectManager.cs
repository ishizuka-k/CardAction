using UnityEngine;
using System.Collections;

using System.Collections.Generic;
public class effData {
	public GameObject effect;
	public string path;
}

public class provData {
	public Vector3  effectPos;
	public float	effectRigor;
	public int	    effectId;
}
public class effectManager : MonoBehaviour {
	//List<effData> effectData = new List<effData>();
	effData[] effectData = new effData[10];
	//List<provData> provisionData = new List<provData>();
	provData[] provisionData = new provData[30];
	int m_idx;
	int m_turn;

	// Use this for initialization
	void Start () {
		m_idx = 0;
		m_turn = 0;
	}
	
	// Update is called once per frame
	public void Update () {
		Debug.Log ("update");
		for (int i = 0; i < m_turn; i++) {

			provisionData[i].effectRigor -= Time.deltaTime;
			Debug.Log ("rigor"+provisionData[i].effectRigor);
			if( provisionData[i].effectRigor < 0 ) {
				Object.Instantiate(effectData[provisionData[i].effectId].effect, provisionData[i].effectPos, Quaternion.identity);
				chageEffect(i);
				m_turn--;
				i--;
			}
		}
	}

	void chageEffect(int turn) {

		for (int i = turn; i < m_turn-1; i++) {
			provisionData[i] = provisionData[i+1];
			}
		provisionData [m_turn - 1] = null;
		}
	public void provisionEffect(Vector3 pos,int id,float rigor) {
		provisionData[m_turn] = new provData();
		provisionData[m_turn].effectPos = pos;
		provisionData[m_turn].effectId = id;
		provisionData[m_turn].effectRigor = rigor;
		m_turn++;
		}
	public int setEffect( string effectPath ) {
		for (int i = 0; i < m_idx; i++) {
			if (effectData[i].path == effectPath) {
					return i;
			}
		}

		//effData tmp;
		//tmp.effect = (GameObject)Resources.Load<GameObject>(effectPath);
		//tmp.path = effectPath;
		//エフェクト
		//effectData.Add (tmp);
		effectData[m_idx] = new effData();
		effectData[m_idx].effect = (GameObject)Resources.Load<GameObject>(effectPath);
		effectData [m_idx].path = effectPath;

		return m_idx++;
	}

	public bool startEffect(int idx,Vector3 pos) {
		Object.Instantiate(effectData[idx].effect, pos, Quaternion.identity);
		return true;
		}
}
