﻿using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    GameObject[] Area = new GameObject[18];
    Player pPlayer;
    //GameObject pPlayer;
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find("Player");
        pPlayer = obj.GetComponent<Player>();
        for(int i = 0 ; i < 18 ; i++)
        {
            string Aname = "Area" + (i+1);
            Area[i] = GameObject.Find(Aname);
            if (i < 9)
            {
                Area[i].renderer.material.color = Color.blue;
                Area[i].tag = "OwnArea";
            }
            else
            {
                Area[i].renderer.material.color = Color.red;
                Area[i].tag = "EnemyArea";
            }
        }
        Debug.Log(pPlayer);
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetMouseButtonDown(0)) {

		Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
 
        if (Physics.Raycast(ray, out hit)){
            GameObject obj = hit.collider.gameObject;

            if (obj.tag == "OwnArea")
            {
					string AreaName = obj.name.Substring(4);
					int AreaIdx = int.Parse(AreaName);
                
					if ( AreaIdx == pPlayer.AreaIdx )
					{
						pPlayer.animator.SetInteger("State", 0);
					}
					else if ( AreaIdx == pPlayer.AreaIdx-1 )
					{
						pPlayer.animator.SetInteger("State", 2);
					}
					else if ( AreaIdx == pPlayer.AreaIdx+1 )
					{
						pPlayer.animator.SetInteger("State", 3);
					}
					else if ( AreaIdx == pPlayer.AreaIdx+3 )
					{
						pPlayer.animator.SetInteger("State", 1);
					}
					else if ( AreaIdx == pPlayer.AreaIdx-3 )
					{
						pPlayer.animator.SetInteger("State", 1);
					}
					else
					{
						return;
					}

					pPlayer.AreaIdx = AreaIdx;
					pPlayer.TargetPoint = new Vector3(obj.transform.position.x,
					                                         obj.transform.position.y + obj.renderer.bounds.size.y*0.5f,
					                                         obj.transform.position.z);
					                                         
			}
            Debug.Log(obj.name);
        }
    }
	}
}
