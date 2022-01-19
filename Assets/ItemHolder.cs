using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public int Number;
    public MainHero MainHero;
    public GameObject Item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeItem()
    {
        Instantiate(MainHero.Items[Number], MainHero.transform.position, Quaternion.identity);
        MainHero.Items[Number] = Item;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
