using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public bool AllowToShoot = true;
    public float Reload;

    public float TimeBetweenShoots;

    public int CountOfBullets;

    public Transform FirePoint;
    public GameObject Bullet;
    public UnityEvent AttackEvent;

    public GameObject Warning;

    public float TimeBeforeShoot;

    public Animator animator;
    // Start is called before the first frame update



    public void Attack()
    {
        AttackEvent.Invoke();
    }

    public void MakeWarning()
    {
        StartCoroutine(IEMakeWarning());
    }

    IEnumerator IEMakeWarning()
    {
        Warning.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Warning.SetActive(false);
        yield break;
    }
    public void Shoot()
    {
        if (AllowToShoot)
        {
            StartCoroutine(OnShoot());
            AllowToShoot = false;
        }
    }
    public IEnumerator OnShoot()
    {
        yield return new WaitForSeconds(TimeBeforeShoot);
        
            for (int i = 0; i < CountOfBullets; i++)
            {
                Quaternion quaternion = transform.parent.gameObject.transform.rotation;
                Instantiate(Bullet, FirePoint.position, quaternion);
                yield return new WaitForSeconds(TimeBetweenShoots);
            }

            yield return new WaitForSeconds(Reload);
            AllowToShoot = true;
       
        yield break;
        
    }

}
