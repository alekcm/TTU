using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseButton : MonoBehaviour
{
    public MainHero Player;
    public Image Image;
    public Sprite StandartIcon;

    private Usable Usable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetStandartSettings()
    {
        Image.sprite = StandartIcon;
        Usable = null;
    }

    
    public void SetSettings(Sprite sprite, Usable usable)
    {
        Image.sprite = sprite;
        Usable = usable;
    }

    public void Use()
    {
        if (Usable!=null)
        Usable.UseEvent.Invoke();
        else Player.Shoot();
    }
    
}
