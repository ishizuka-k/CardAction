using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {
    public Animator animator;
	public int 		AreaIdx;
	public float 	rigor;
	public Vector3 	TargetPoint;
	public Vector3 	StartPoint;
	public float[]	nowCard = new float[5];
	GameManager GM;
	// Use this for initialization
	void Start () {
        //アニメーター初期化
        animator = GetComponent<Animator>();

        //初期値設定
		StartPoint = GameObject.Find("Area2").transform.position;
		this.gameObject.transform.position = new Vector3(StartPoint.x,
		                                                 StartPoint.y + GameObject.Find("Area2").renderer.bounds.size.y*0.5f,
		                                                 StartPoint.z);
		StartPoint 	= TargetPoint = this.gameObject.transform.position;
		AreaIdx 	= 2;
		rigor 		= 0;
		GM = GameManager.Instance;

		for (int i = 0; i < 5; i++) {
			nowCard [i]		= GM.GetCard(i).wait;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//
		for (int i = 0; i < 5; i++) {
			if (nowCard [i] < GM.GetCard (i).wait) {
				nowCard[i] += Time.deltaTime;
			}
		}

		// move
		GameManager.Instance.getEffectInstance().Update();
		if ((this.transform.position.x >= TargetPoint.x + 0.1f || this.transform.position.x <= TargetPoint.x - 0.1f) || 
						(this.transform.position.z >= TargetPoint.z + 0.1f || this.transform.position.z <= TargetPoint.z - 0.1f)) {
						this.transform.position = new Vector3 (this.transform.position.x + ((TargetPoint.x - StartPoint.x) * 0.1f),
		                                       this.transform.position.y + ((TargetPoint.y - StartPoint.y) * 0.1f),
		                                       this.transform.position.z + ((TargetPoint.z - StartPoint.z) * 0.1f));

						StartPoint = this.transform.position;

		} else if ( rigor > 0 ) {
			rigor -= Time.deltaTime;
			animator.SetFloat ("rigor", rigor);
		} else if( animator.GetInteger("State") != 0){

			Debug.Log("animechage");
			animator.SetInteger ("State", 0);
		}
	}
}
