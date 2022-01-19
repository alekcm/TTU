using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obsticle : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health;
    public float TakedDamage;
    public UnityEvent OnHitEvent;
    public UnityEvent OnDieEvent;
    void Start()
    {
        GameObject Room = GameObject.Find("Комната(Clone)");
        gameObject.transform.parent = Room.transform;
    }

    public void TakeDamage()
    {
        Health -= TakedDamage;
        if (Health<=0)
            OnDieEvent.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
