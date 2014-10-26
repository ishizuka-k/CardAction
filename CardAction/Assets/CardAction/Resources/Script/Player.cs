using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {
    public Animator animator;
	// Use this for initialization
	void Start () {
        //アニメーター初期化
        animator = GetComponent<Animator>();

        //初期値設定
        Vector3 StartPos = GameObject.Find("Area2").transform.position;
        this.gameObject.transform.position = new Vector3(StartPos.x, StartPos.y + GameObject.Find("Area2").renderer.bounds.size.y, StartPos.z);
        Debug.Log("X" + this.gameObject.transform.position.x + " Y " + this.gameObject.transform.position.y + " Z " + this.gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        //animator.SetInteger("State", 2);
        //Debug.Log("X");
	}
}
