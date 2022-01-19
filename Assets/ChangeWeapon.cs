using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    public MainHero MainHero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeCurrentWeapon()
    {
        for (int i = 0; i < MainHero.Guns.Length; i++)
        {
            if (MainHero.Guns[i].active)
            {
                MainHero.Guns[i].SetActive(false);
                if (i < MainHero.Guns.Length - 1)
                    i++;
                else
                    i = 0;
                MainHero.Guns[i].SetActive(true);
                MainHero.WearableWeapon = MainHero.Guns[i].GetComponent<Weapon>();
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
