using UnityEngine;
using System.Collections;

public class Bom : MonoBehaviour {
	Player pPlayer;
	public int AreaIdx;
	public int NextAreaIdx;
	Vector3[] ControlPoint = new Vector3[4];
	float TimeMax;
	float TimeNow;
	int nAtk;

	void Start () {
		GameObject obj = GameObject.Find("Player");
		pPlayer = obj.GetComponent<Player>();
		AreaIdx = pPlayer.AreaIdx;
		NextAreaIdx = AreaIdx + 9;
		Debug.Log ("NextAreaIdx"+NextAreaIdx);
		nAtk = 5;
		TimeNow = 0;
		GameObject nextArea = GameObject.Find("Area"+NextAreaIdx);
		ControlPoint [0] = pPlayer.transform.position;
		ControlPoint [3] = new Vector3 (nextArea.transform.position.x,
		                                nextArea.transform.position.y+1.0f,
		                                nextArea.transform.position.z);
		Vector3 Vec = ControlPoint [3] - ControlPoint [0];

		ControlPoint [1].x = ControlPoint [0].x + Vec.x / 3.0f;
		ControlPoint [1].z = ControlPoint [0].z + Vec.z / 3.0f;
		ControlPoint [1].y = ControlPoint [0].y + 3.0f;

		ControlPoint [2].x = ControlPoint [0].x + Vec.x / 3.0f*2.0f;
		ControlPoint [2].z = ControlPoint [0].z + Vec.z / 3.0f*2.0f;
		ControlPoint [2].y = ControlPoint [0].y + 3.0f;

		if( Vec.x < 0)
		{
			Vec.x *= -1.0f;
		} else if( Vec.z < 0)
		{
			Vec.z *= -1.0f;
		}

		TimeMax = (Vec.x + Vec.y + Vec.z)*5.0f;

		this.gameObject.transform.position = ControlPoint [0];
		//this.gameObject.transform.Rotate (new Vector3(0,90,0));
	}
	
	// Update is called once per frame
	void Update () {
		float fHokan = TimeNow / TimeMax;
			this.gameObject.transform.position = new Vector3 (( 1 - fHokan ) * ( 1 - fHokan ) * ( 1 - fHokan ) * ControlPoint[0].x + 3 * ( 1 - fHokan ) * ( 1 - fHokan ) * fHokan * ControlPoint[1].x +
			                                                  3 * ( 1 - fHokan ) * fHokan * fHokan * ControlPoint[2].x + fHokan * fHokan * fHokan * ControlPoint[3].x,
			                                                  ( 1 - fHokan ) * ( 1 - fHokan ) * ( 1 - fHokan ) * ControlPoint[0].y + 3 * ( 1 - fHokan ) * ( 1 - fHokan ) * fHokan * ControlPoint[1].y +
			                                                  3 * ( 1 - fHokan ) * fHokan * fHokan * ControlPoint[2].y + fHokan * fHokan * fHokan * ControlPoint[3].y,
			                                                  ( 1 - fHokan ) * ( 1 - fHokan ) * ( 1 - fHokan ) * ControlPoint[0].z + 3 * ( 1 - fHokan ) * ( 1 - fHokan ) * fHokan * ControlPoint[1].z +
			                                                  3 * ( 1 - fHokan ) * fHokan * fHokan * ControlPoint[2].z + fHokan * fHokan * fHokan * ControlPoint[3].z);

		if (TimeNow < TimeMax) {
						TimeNow += 1.0f;
		} else {
			Destroy (this.gameObject);
			Object.Instantiate((GameObject)Resources.Load<GameObject>("prefab/exploPrefab"),this.transform.position , Quaternion.identity);
			GameObject[] objs = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach(GameObject obj in objs) {
				enemy pEnemy = obj.GetComponent<enemy>();
				if ( NextAreaIdx == pEnemy.AreaIdx ) {
					pEnemy.nHp -= nAtk;
					if ( pEnemy.nHp <= 0 ) {
						Object.Destroy(obj);
					}
					break;
				}
			}
		}
	}
}
