using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Text Description;
    public MainHero MainHero;
    
    // Start is called before the first frame update
    void Start()
    {
        MainHero = GameObject.Find("Main Hero").GetComponent<MainHero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
