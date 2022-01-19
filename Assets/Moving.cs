using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Moving : MonoBehaviour
{
    public MainHero MainHero;

    public Vector2 Direction;

    public RectTransform RectTransform, FatherRectTransform;

    private float Lenght;
    // Start is called before the first frame updat

    void Start()
    {
       // FatherRectTransform.sizeDelta = new Vector2(Screen.width / 7, Screen.width / 7);
       // RectTransform.sizeDelta = new Vector2(Screen.width / 25, Screen.width / 25);
        Lenght = FatherRectTransform.sizeDelta.x/2;
        
    }


    // Update is called once per fram
    void Update()
    {
        if (Input.mousePosition.x<FatherRectTransform.sizeDelta.x+RectTransform.sizeDelta.x &&Input.mousePosition.y<FatherRectTransform.sizeDelta.y+RectTransform.sizeDelta.y)
        gameObject.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        else RectTransform.anchoredPosition = new Vector2(0, 0);
        if (Application.platform == RuntimePlatform.Android)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
                RectTransform.anchoredPosition = new Vector2(0, 0);
        }
        if (RectTransform.anchoredPosition.x > Lenght)
            RectTransform.anchoredPosition = new Vector2(Lenght, RectTransform.anchoredPosition.y);
        if (RectTransform.anchoredPosition.x < -Lenght)
            RectTransform.anchoredPosition = new Vector2(-Lenght, RectTransform.anchoredPosition.y);
        if (RectTransform.anchoredPosition.y > Lenght)
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x,Lenght);
        if (RectTransform.anchoredPosition.y < -Lenght)
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x,-Lenght);
        Direction = new Vector2(RectTransform.anchoredPosition.x/Lenght, RectTransform.anchoredPosition.y/Lenght);
        MainHero.Direction = Direction;
    }
}
