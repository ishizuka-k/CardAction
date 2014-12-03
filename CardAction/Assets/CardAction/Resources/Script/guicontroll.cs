using UnityEngine;
using System.Collections;
[ExecuteInEditMode()]
public class guicontroll : MonoBehaviour {
    public Texture pTextture;
	GameManager GM;
	attckContoller AC;
    int touchNumber;
	Vector3 TouchPoint;
	Player pPlayer;
	public bool swap;
	

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find("Player");
		pPlayer = obj.GetComponent<Player>();
		touchNumber = -1;
		TouchPoint = new Vector3 (0,0,0);
		swap = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){

		GM = GameManager.Instance;

        if (Input.GetMouseButtonUp(0))
        {
			if ( swap == false && touchNumber != -1) {
				AC = attckContoller.Instance;
				AC.AttckJudge(touchNumber);
				pPlayer.nowCard[touchNumber] = 0;
			}
            touchNumber = -1;
			swap = false;
        }
        for (int i = 0; i < 5; i++ )
        {
			Rect testRect = new Rect(i * Screen.width / 5.0f, Screen.height - Screen.height / 10.0f, Screen.width / 5.0f, Screen.height / 10.0f);
			Rect gaugeRect = new Rect(i * Screen.width / 5.0f, testRect.y-Screen.height / 50.0f, Screen.width / 5.0f, Screen.height / 50.0f);

            rectifyRectScale(ref testRect);
			rectifyRectScale(ref gaugeRect);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (testRect.x < Input.mousePosition.x && Input.mousePosition.x < testRect.x + testRect.width)
                {
                    if (testRect.y < (Screen.height - Input.mousePosition.y) && (Screen.height - Input.mousePosition.y) < testRect.y + testRect.height)
                    {
						if (pPlayer.nowCard [i] >= GM.GetCard (i).wait)
						{
							if (pPlayer.rigor <= 0)
							{
								TouchPoint = Input.mousePosition;
                     	 		touchNumber = i;
							}
						}
                    }
                }
            }

            if (touchNumber == i)
            {
				if( TouchPoint.x + 0.1f <  Input.mousePosition.x || TouchPoint.x - 0.1f >  Input.mousePosition.x 
				   || TouchPoint.y + 0.1f <  Input.mousePosition.y || TouchPoint.y - 0.1f >  Input.mousePosition.y)
				{
					Debug.Log("tx"+TouchPoint.x+"ty"+TouchPoint.y);
					Debug.Log("mx"+Input.mousePosition.x+"my"+Input.mousePosition.y);
                	testRect = new Rect(Input.mousePosition.x - (Screen.width / 5.0f) * 0.5f,
					                    (Screen.height-Input.mousePosition.y) - (Screen.height / 10.0f) * 0.5f,
					                    Screen.width / 5.0f,
					                    Screen.height / 10.0f);
					swap = true;
				}
            }
			gaugeRect.width = pPlayer.nowCard[i]/GM.GetCard(i).wait*Screen.width / 5.0f;
			GUI.DrawTexture(testRect, (Texture)GM.GetCard(i).tex);
			GUI.DrawTexture(gaugeRect, (Texture)Resources.Load<Texture>("image/mask"));
        }
	}

    private int w = 320;

    private int h = 480;
    private Rect rectifyRectScale(ref Rect pos)
    {
        Rect new_pos = new Rect();
        new_pos.x = (pos.x / w) * Screen.width;
        new_pos.y = (pos.y / h) * Screen.height;
        new_pos.width = (pos.width / w) * Screen.width;
        new_pos.height = (pos.height / h) * Screen.height;
        return new_pos;
    }
}
