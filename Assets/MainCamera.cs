using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    
    public Transform MainHero;   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    public void Update()
    {
        /*transform.position = new Vector3(MainHero.position.x, MainHero.position.y, -1);*/
        /*float RangeX = transform.position.x - MainHero.transform.position.x;
        float RangeY = transform.position.y - MainHero.transform.position.y;
        if (RangeX > 1f)
        {
            transform.position = new Vector3(MainHero.position.x+1f, MainHero.position.y + RangeY, -1);
        }
        if (RangeY > 1f)
        {
            transform.position = new Vector3(MainHero.position.x+RangeX, MainHero.position.y + 1f, -1);
        }
        if (RangeX < -1f)
        {
            transform.position = new Vector3(MainHero.position.x-1f, MainHero.position.y + RangeY, -1);
        }
        if (RangeY < -1f)
        {
            transform.position = new Vector3(MainHero.position.x+RangeX, MainHero.position.y - 1f, -1);
        }*/
    }

    public IEnumerator Jump()
    {
        Vector3 vector3 = new Vector3(MainHero.position.x, MainHero.position.y, -1f);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Jump());
        for (int i = 0; i < 100; i++)
        {
            transform.position = Vector3.MoveTowards(transform.position, vector3, 0.01f);
            yield return new WaitForSeconds(0.0001f);
        }


        yield break;
    }
}
