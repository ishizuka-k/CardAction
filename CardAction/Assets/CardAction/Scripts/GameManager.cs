using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    static 
    GameObject[] Area = new GameObject[18];

	// Use this for initialization
	void Start () {
        for(int i = 0 ; i < 18 ; i++)
        {
            string Aname = "Area" + (i+1);
            Area[i] = GameObject.Find(Aname);
            if (i < 9)
            {
                Area[i].renderer.material.color = Color.blue;
            }
            else
            {
                Area[i].renderer.material.color = Color.red;
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
    if (Input.GetMouseButtonDown(0)) {
 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
 
        if (Physics.Raycast(ray, out hit)){
            GameObject obj = hit.collider.gameObject;
            Debug.Log(obj.name);
        }
    }
	}
}
