using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class enemy : MonoBehaviour {
	public Animator animator;
	public int AreaIdx;
	float maxHp;
	public float nHp;
	float maxScale;
	public Vector3 TargetPoint;
	public Vector3 StartPoint;
	GameObject gaugeObj;
	GameObject[] Area = new GameObject[18];
	float wait;
	// Use this for initialization
	void Start () {
		//アニメーター初期化
		animator = GetComponent<Animator>();
		
		//初期値設定
		StartPoint = GameObject.Find("Area11").transform.position;
		this.gameObject.transform.position = new Vector3(StartPoint.x,
		                                                 StartPoint.y + GameObject.Find("Area17").renderer.bounds.size.y*0.5f,
		                                                 StartPoint.z);
		StartPoint = TargetPoint = this.gameObject.transform.position;
		Vector3 gaugePoint = new Vector3 (this.gameObject.transform.position.x-this.gameObject.transform.localScale.x*0.5f,
		                                  this.gameObject.transform.position.y+this.gameObject.transform.localScale.y*2.0f,
		                                  this.gameObject.transform.position.z);
		gaugeObj = (GameObject)Object.Instantiate((GameObject)Resources.Load<GameObject>("prefab/gaugePrefab"),gaugePoint , Quaternion.identity);
		AreaIdx = 11;
		maxHp = 10;
		nHp = 10;
		wait = 3.0f;
		maxScale = gaugeObj.transform.localScale.x;

		for (int i = 0; i < 18; i++) 
		{
			string Aname = "Area" + (i + 1);
			Area [i] = GameObject.Find (Aname);
		}
	}
	
	// Update is called once per frame
	void Update () {
		gaugeObj.transform.localScale = new Vector3( maxScale*(nHp/maxHp),
		                                              gaugeObj.transform.localScale.y,
		                                              gaugeObj.transform.localScale.z);
		if (wait < 0) {
			int[] emArea = new int[18];
			int idx = 0;
			for (int i = 0; i < 18; i++) {
					if (Area [i].tag == "EnemyArea") {
							emArea [idx] = i;
							idx++;
					}
			}

			int hit = emArea [Random.Range (0, idx)];
			AreaIdx = hit+1;
			this.gameObject.transform.position = Area [hit].transform.position;
			gaugeObj.transform.position = new Vector3 (this.gameObject.transform.position.x-this.gameObject.transform.localScale.x*0.5f,
			                                           this.gameObject.transform.position.y+this.gameObject.transform.localScale.y*2.0f,
			                                           this.gameObject.transform.position.z);
			wait = 3.0f;
		} else {
			wait -= Time.deltaTime;
		}
	}

	public void DeleteEnemy(){
		Destroy(gaugeObj);
		Destroy(this.gameObject);
	}
}
