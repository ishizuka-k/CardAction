﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class enemy : MonoBehaviour {
	public Animator animator;
	public int AreaIdx;
	public int nHp;
	public Vector3 TargetPoint;
	public Vector3 StartPoint;
	// Use this for initialization
	void Start () {
		//アニメーター初期化
		animator = GetComponent<Animator>();
		
		//初期値設定
		StartPoint = GameObject.Find("Area11").transform.position;
		this.gameObject.transform.position = new Vector3(StartPoint.x,
		                                                 StartPoint.y + GameObject.Find("Area17").renderer.bounds.size.y*0.5f,
		                                                 StartPoint.z);
		StartPoint =TargetPoint = this.gameObject.transform.position;
		AreaIdx = 11;
		nHp = 10;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		Debug.Log ("enemyHP"+nHp);
		if ((this.transform.position.x >= TargetPoint.x + 0.1f || this.transform.position.x <= TargetPoint.x - 0.1f) || 
		    (this.transform.position.z >= TargetPoint.z + 0.1f || this.transform.position.z <= TargetPoint.z - 0.1f)) {
			this.transform.position = new Vector3 (this.transform.position.x + ((TargetPoint.x - StartPoint.x) * 0.1f),
			                                       this.transform.position.y + ((TargetPoint.y - StartPoint.y) * 0.1f),
			                                       this.transform.position.z + ((TargetPoint.z - StartPoint.z) * 0.1f));
			//float Angle = Mathf.Atan2 (TargetPoint.x - StartPoint.x, TargetPoint.z - StartPoint.z);	
			//this.transform.rotation = Quaternion.Euler (0.0f, Angle * Mathf.Rad2Deg, 0.0f);
			StartPoint = this.transform.position;
			Debug.Log("this X: "+this.transform.position.x + "Z : "+this.transform.position.z);
			Debug.Log("target X: "+TargetPoint.x + "Z : "+TargetPoint.z);
		} else if( animator.GetInteger("State") != 0 ){
			animator.SetInteger ("State", 0);
		}
		*/
	}
}
