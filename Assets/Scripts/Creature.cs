using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Creature : MonoBehaviour
{
    public StyleRank StyleRank;
    public Vector2 PlaceWhereITakeDamage;
    public GameObject Particles;
    public float Health;

    public float MoveSpeed;

    public float DamageResistance = 1;
    public int TakedDamage;
    public UnityEvent OnTakenDamage, OnDieEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SplitBlood()
    {
        for (int i = 0; i < TakedDamage; i++)
        {
            GameObject NewParticles = Instantiate(Particles, transform);
            NewParticles.SetActive(true);
            NewParticles.transform.SetParent(transform);
            ParticlsFather father = NewParticles.GetComponent<ParticlsFather>();
            father.PlaceWhereITakeDamage = PlaceWhereITakeDamage;
            father.Change();
        }
    }

    public void TakeDamage()
    {
        Health -= TakedDamage/DamageResistance;
        if (Health <= 0)
            Die();
    }

    public void AddStyleScore()
    {
        StyleRank.ChangeScore(TakedDamage);
    }

    public void AddKillingStreak()
    {
        StyleRank.ContinueStreak();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        OnDieEvent.Invoke();
    }
}
