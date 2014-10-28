using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    GameObject Player;
    GameObject LookAt;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        LookAt = GameObject.Find("Area8");
        this.gameObject.transform.position = (new Vector3(Player.transform.position.x, Player.transform.position.y + 10, Player.transform.position.z-3));
        this.gameObject.transform.LookAt(LookAt.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
