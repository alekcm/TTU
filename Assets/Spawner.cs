using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x + Random.Range(-0.1f, 0.1f),
            transform.position.y + Random.Range(-0.1f, 0.1f));
        Spawn();
    }
    public void Spawn()
    {
        StartCoroutine(StartSpawn());

    }

    IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(1.1f);
        Instantiate(Enemy, transform.position, Quaternion.identity);
        Enemy.transform.parent = gameObject.transform.parent;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        yield break;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
