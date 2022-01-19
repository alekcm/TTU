using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public GameObject Father;
    public int AddHealth, AddArmor, AddMaxHealth, AddMaxArmor;

    private Health HealthUI;
    // Start is called before the first frame update
    void Start()
    {
        HealthUI = GameObject.Find("Скрипт здоровья").GetComponent<Health>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player" && !collider2D.isTrigger)
        {
            if (AddMaxArmor>0)
                HealthUI.AddMaxArmor(AddMaxArmor);
            if (AddMaxHealth>0)
                HealthUI.AddMaxHealth(AddMaxHealth);
            if (AddHealth>0)
                HealthUI.RestoreHealth(AddHealth);
            if (AddArmor>0)
                HealthUI.RestoreArmor(AddArmor);
            Destroy(Father);
        }
    }
}
