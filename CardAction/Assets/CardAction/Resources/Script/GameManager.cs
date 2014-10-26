using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    GameObject[] Area = new GameObject[18];
    Player pPlayer;
    //GameObject pPlayer;
	// Use this for initialization
	void Start () {
        //pPlayer = GameObject.Find("Player");
        pPlayer = GetComponent<Player>();
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
                pPlayer.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + obj.renderer.bounds.size.y, obj.transform.position.z);
                //GetComponent<Player>().animator.SetInteger("State", 1);
			}
            Debug.Log(obj.name);
        }
    }
	}
}
