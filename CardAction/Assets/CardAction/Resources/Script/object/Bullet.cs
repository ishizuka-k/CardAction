using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	Player pPlayer;
	public int AreaIdx;
	public int NextAreaIdx;
	int nMoveCnt;
	int nAtk;
	/*
	public Bullet(int _AreaIdx,int _atk) {
		AreaIdx = _AreaIdx;
		NextAreaIdx = AreaIdx + 3;
		nAtk = _atk;
		}
		*/
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find("Player");
		pPlayer = obj.GetComponent<Player>();
		nMoveCnt = 0;
		AreaIdx = pPlayer.AreaIdx;
		NextAreaIdx = AreaIdx + 3;
		nAtk = 3;
		this.gameObject.transform.Rotate (new Vector3(0,90,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (nMoveCnt < 10) {
					GameObject nowArea = GameObject.Find ("Area" + AreaIdx);
					Vector3 s_pos = new Vector3 (nowArea.transform.position.x, nowArea.transform.position.y + 1.0f, nowArea.transform.position.z);
					GameObject nextArea = GameObject.Find ("Area" + NextAreaIdx);
					Vector3 t_pos = new Vector3 (nextArea.transform.position.x, nextArea.transform.position.y + 1.0f, nextArea.transform.position.z);
					this.transform.position = new Vector3 (this.transform.position.x + ((t_pos.x - s_pos.x) * 0.1f),
		                                       this.transform.position.y + ((t_pos.y - s_pos.y) * 0.1f),
		                                       this.transform.position.z + ((t_pos.z - s_pos.z) * 0.1f));
			nMoveCnt++;
			} else {
				AreaIdx = NextAreaIdx;
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach(GameObject obj in objs) {
				enemy pEnemy = obj.GetComponent<enemy>();
				if ( NextAreaIdx == pEnemy.AreaIdx ) {
					pEnemy.nHp -= nAtk;
					Destroy (this.gameObject);
					Object.Instantiate((GameObject)Resources.Load<GameObject>("prefab/exploPrefab"),this.transform.position , Quaternion.identity);
					if ( pEnemy.nHp <= 0 ) {
						pEnemy.DeleteEnemy();
					}
					break;
				}
			}

				NextAreaIdx += 3;
				if (NextAreaIdx > 18) {
						Destroy (this.gameObject);
				}
				nMoveCnt = 0;
			}
		}
}
