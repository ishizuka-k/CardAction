using UnityEngine;
using System.Collections;
[ExecuteInEditMode()]
public class guicontroll : MonoBehaviour {
    public Texture pTextture;
	GameManager GM;
    int touchNumber = -1;
	Vector3 TouchPoint;
	

	// Use this for initialization
	void Start () {
		TouchPoint = new Vector3 (0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){

		GM = GameManager.Instance;

        if (Input.GetMouseButtonUp(0))
        {
            touchNumber = -1;
        }
        for (int i = 0; i < 5; i++ )
        {
			Rect testRect = new Rect(i * Screen.width / 5.0f, Screen.height - Screen.height / 10.0f, Screen.width / 5.0f, Screen.height / 10.0f);
            //Rect testRect = new Rect(0, 0, 100, 100);
            rectifyRectScale(ref testRect);
            
            if (Input.GetMouseButtonDown(0))
            {
                if (testRect.x < Input.mousePosition.x && Input.mousePosition.x < testRect.x + testRect.width)
                {
                    if (testRect.y < (Screen.height - Input.mousePosition.y) && (Screen.height - Input.mousePosition.y) < testRect.y + testRect.height)
                    {
						TouchPoint = Input.mousePosition;
                        touchNumber = i;
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
				}
            }
			GUI.DrawTexture(testRect, (Texture)GM.GetCard(i).tex);
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
