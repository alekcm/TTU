using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float ScaleSize;
    public StyleRank StyleRank;
    public Text HealthText, ArmorText;
    public RectTransform EmptyHealth, CurrentHealth, EmptyArmor, CurrentArmor;
    public int ArmorCount, HealthCount, MaxArmorCount, MaxHealthCount;
    private Vector2 HealthTransform,ArmorTransform;
    void Start()
    {
        ScaleSize = Screen.width / 600;
        GetValues();
        EmptyHealth.sizeDelta = new Vector2(MaxHealthCount*ScaleSize,EmptyHealth.sizeDelta.y);
        CurrentHealth.sizeDelta = new Vector2(HealthCount*ScaleSize,CurrentHealth.sizeDelta.y);
        EmptyArmor.sizeDelta = new Vector2(MaxArmorCount*ScaleSize,EmptyArmor.sizeDelta.y);
        CurrentArmor.sizeDelta = new Vector2(ArmorCount*ScaleSize,CurrentArmor.sizeDelta.y);
        CurrentArmor.anchoredPosition = new Vector2(ArmorCount * ScaleSize / 2, CurrentArmor.anchoredPosition.y);
        EmptyArmor.anchoredPosition = new Vector2(MaxArmorCount * ScaleSize / 2, EmptyArmor.anchoredPosition.y);
        CurrentHealth.anchoredPosition = new Vector2(HealthCount * ScaleSize / 2, CurrentHealth.anchoredPosition.y);
        EmptyHealth.anchoredPosition = new Vector2(MaxHealthCount * ScaleSize / 2, EmptyHealth.anchoredPosition.y);
        HealthText.text = Convert.ToString(HealthCount);
        ArmorText.text = Convert.ToString(ArmorCount);

    }

    public void SetValues()
    {
        PlayerPrefs.SetInt("Armor", ArmorCount);
        PlayerPrefs.SetInt("MaxArmor", MaxArmorCount);
        PlayerPrefs.SetInt("Health", HealthCount);
        PlayerPrefs.SetInt("MaxHealth", MaxHealthCount);
    }

    public void GetValues()
    {
        ArmorCount = PlayerPrefs.GetInt("Armor");
        MaxArmorCount = PlayerPrefs.GetInt("MaxArmor");
        HealthCount = PlayerPrefs.GetInt("Health");
        MaxHealthCount = PlayerPrefs.GetInt("MaxHealth");
    }

    public void AddMaxArmor(int Add)
    {
        MaxArmorCount += Add;
        EmptyArmor.sizeDelta = new Vector2(MaxArmorCount*ScaleSize,EmptyArmor.sizeDelta.y);
        EmptyArmor.anchoredPosition = new Vector2(MaxArmorCount * ScaleSize / 2, EmptyArmor.anchoredPosition.y);
        ChangeArmor(Add);
    }
    public void AddMaxHealth(int Add)
    {
        MaxHealthCount += Add;
        EmptyHealth.sizeDelta = new Vector2(MaxHealthCount*ScaleSize,EmptyHealth.sizeDelta.y);
        EmptyHealth.anchoredPosition = new Vector2(MaxHealthCount * ScaleSize / 2, EmptyHealth.anchoredPosition.y);
        ChangeHealth(Add);
    }

    private void ChangeHealth(int Health)
    {
        HealthCount += Health;
        if (HealthCount > MaxHealthCount)
            HealthCount = MaxHealthCount;
        if (HealthCount < 0)
            HealthCount = 0;
        HealthText.text = Convert.ToString(HealthCount);
        CurrentHealth.sizeDelta = new Vector2(HealthCount*ScaleSize,CurrentHealth.sizeDelta.y);
        CurrentHealth.anchoredPosition = new Vector2(HealthCount * ScaleSize / 2, CurrentHealth.anchoredPosition.y);
    }
    private void ChangeArmor(int Armor)
    {
        ArmorCount += Armor;
        if (ArmorCount > MaxArmorCount)
            ArmorCount = MaxArmorCount;
        if (ArmorCount < 0)
            ArmorCount = 0;
        ArmorText.text = Convert.ToString(ArmorCount);
        CurrentArmor.sizeDelta = new Vector2(ArmorCount*ScaleSize,CurrentArmor.sizeDelta.y);
        CurrentArmor.anchoredPosition = new Vector2(ArmorCount * ScaleSize / 2, CurrentArmor.anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int Damage)
    {
        StyleRank.ChangeScore(-Damage*2);
        int HealthDamage = ArmorCount - Damage;
        if (HealthDamage<0)
            ChangeHealth(HealthDamage);
        if (ArmorCount>0)
        ChangeArmor(-Damage);
        
    }

    public void RestoreHealth(int Health)
    {ChangeHealth(Health);
        
    }
    public void RestoreArmor(int Armor)
    {ChangeArmor(Armor);
        
    }
}
