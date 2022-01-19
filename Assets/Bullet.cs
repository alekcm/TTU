using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public bool Friendly;
    public int Damage;

    public float TimeOfLife;
    public float Speed;
    public float Accuracy;
    public bool RandomTraectory;
    private Creature _creature;
    private Obsticle _obsticle;
    public Vector3 rotation;
    public OnFlyEvent FlyEvent;
    public UnityEvent OnEnemyHitEvent, OnWallHitEvent, OnPlayerHitEvent;
    // Start is called before the first frame update
    void Start()
    {
        Accuracy /= 2;
        if (TimeOfLife != 0)
            StartCoroutine(StartDieAfterTime(TimeOfLife));
            
        transform.Rotate(0, 0, Random.Range(-Accuracy, Accuracy));
        FlyEvent.Invoke();
    }


[System.Serializable]
    public class OnFlyEvent: UnityEvent{}

    // Update is called once per frame
    void Update()
    {
        if (RandomTraectory)
            transform.Rotate(0, 0, Random.Range(-Accuracy, Accuracy));
    }

    public void HitEnemy()
    {
        OnEnemyHitEvent.Invoke();
    }

    public void HitPlayer()
    {
        OnPlayerHitEvent.Invoke();
    }
    public void HitWall()
    {
        OnWallHitEvent.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Bounce()
    {
        transform.rotation = Quaternion.Inverse(transform.rotation);
    }

    public void MakeDamage()
    {
        if (_creature != null)
        {
            _creature.TakedDamage = Damage;
            _creature.OnTakenDamage.Invoke();
        }

        if (_obsticle != null)
        {
            _obsticle.TakedDamage = Damage;
            _obsticle.OnHitEvent.Invoke();
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        
        if (collider2D.tag == "Enemy" && Friendly)
        {
            _creature = collider2D.gameObject.GetComponent<Creature>();
            collider2D.gameObject.GetComponent<Creature>().PlaceWhereITakeDamage = gameObject.transform.position;
            HitEnemy();
        }

        if (collider2D.tag == "Wall")
        {
            _obsticle = collider2D.gameObject.GetComponent<Obsticle>();
            HitWall();
        }

        if (collider2D.tag == "Player" && !Friendly)
        {
            _creature = collider2D.gameObject.GetComponent<Creature>();
            HitPlayer();
        }
    }

    public void FlyForward()
    {
        StartCoroutine(OnFlyForward());
    }

    public IEnumerator OnFlyForward()
    {
        while (true){
           transform.Translate( Vector2.right* Speed * Time.deltaTime);
           yield return  new WaitForEndOfFrame();
        }

        yield break;
    }

    public void Rotate(float RotationSpeed)
    {
        StartCoroutine(StartRotate(RotationSpeed));
    }
    public IEnumerator StartRotate(float RotationSpeed)
    {
        while (true)
        {
            Vector3 rot = new Vector3(0,0,transform.rotation.z+RotationSpeed);
            gameObject.transform.Rotate(rot);
        }
        yield break;
    }

    public void DieAfterTime(float TimeOfLife)
    {
        StartCoroutine(StartDieAfterTime(TimeOfLife));
    }
    public IEnumerator StartDieAfterTime(float TimeOfLife)
    {
        yield return new WaitForSeconds(TimeOfLife);
        Destroy(gameObject);
        yield break;
    }
}
