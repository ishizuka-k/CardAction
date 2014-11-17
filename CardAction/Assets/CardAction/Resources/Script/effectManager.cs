using UnityEngine;
using System.Collections;
public class effData {
	public GameObject effect;
	public string path;
}
public class effectManager : MonoBehaviour {
	effData[] effectData;
	int m_idx;

	// Use this for initialization
	void Start () {
		m_idx = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int setEffect( string effectPath ) {

		for (int i = 0; i < m_idx; i++) {
			if (effectData[m_idx].path == effectPath) {
					return i;
			}
		}
		//エフェクト
		effectData[m_idx].effect = (GameObject)Resources.Load<GameObject>(effectPath);
		return m_idx++;
	}

	public bool startEffect(int idx,Vector3 pos) {
		Object.Instantiate(effectData[idx].effect, pos, Quaternion.identity);
		return true;
		}
}
