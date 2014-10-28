using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
    GameObject Player;
    GameObject LookAt;
    public float height;
    public float EtoAlength;
    Vector3 StartPoint;

	// Use this for initialization
	void Start () {
        height = 10;
        EtoAlength = -3;
        Player = GameObject.Find("Player");
        LookAt = GameObject.Find("Area8");
        this.gameObject.transform.position = (new Vector3(Player.transform.position.x,
            Player.transform.position.y + height,
            Player.transform.position.z + EtoAlength));
        this.gameObject.transform.LookAt(LookAt.transform.position);
        StartPoint = this.gameObject.transform.position;
	}
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, Screen.width * 0.2f, Screen.height * 0.025f), "カメラの高さ");
        if (GUI.Button(new Rect(0, Screen.height * 0.025f, Screen.width * 0.1f, Screen.height * 0.025f), "↑"))
        {
            this.gameObject.transform.Translate(new Vector3(0, 1, 0));
            height += 1;
            StartPoint.y += 1;
        }
        GUI.Label(new Rect(0, Screen.height * 0.05f, Screen.width * 0.1f, Screen.height * 0.025f), "" + height);
        if (GUI.Button(new Rect(0, Screen.height * 0.075f, Screen.width * 0.1f, Screen.height * 0.025f), "↓"))
        {
            this.gameObject.transform.Translate(new Vector3(0, -1, 0));
            height -= 1;
            StartPoint.y -= 1;
        }

        GUI.Label(new Rect(Screen.width * 0.2f, 0, Screen.width * 0.2f, Screen.height * 0.025f), "視点との距離");
        if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.025f, Screen.width * 0.1f, Screen.height * 0.025f), "↑"))
        {
            float Angle = Mathf.Atan2(LookAt.transform.position.y - StartPoint.y,
                LookAt.transform.position.z - StartPoint.z);
            Debug.Log("Angle" + Angle + " cos" + Mathf.Cos(Angle) + " sin" + Mathf.Sin(Angle));
            this.gameObject.transform.Translate(new Vector3(0, Mathf.Sin(-Angle), Mathf.Cos(-Angle)));
            EtoAlength += 1;
        }
        GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.05f, Screen.width * 0.1f, Screen.height * 0.025f), "" + EtoAlength);
        if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.075f, Screen.width * 0.1f, Screen.height * 0.025f), "↓"))
        {
            float Angle = Mathf.Atan2(LookAt.transform.position.y - StartPoint.y,
                LookAt.transform.position.z - StartPoint.z);
            Debug.Log("Angle" + Angle + " cos" + Mathf.Cos(Angle) + " sin" + Mathf.Sin(Angle));
            this.gameObject.transform.Translate(new Vector3(0, -Mathf.Sin(-Angle), -Mathf.Cos(-Angle)));
            EtoAlength -= 1;
        }
    }
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.LookAt(LookAt.transform.position);
        /*
        this.gameObject.transform.position = (new Vector3(Player.transform.position.x,
            Player.transform.position.y + height,
            Player.transform.position.z + EtoAlength));
         * */
	}
}
