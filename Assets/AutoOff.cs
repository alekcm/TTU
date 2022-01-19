using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AutoOff : MonoBehaviour
{
     public GameObject main;
    // Start is called before the first frame update
    void Start()
    {
        Transform Tr = gameObject.GetComponent<Transform>();
        Tr.position = new Vector3(Tr.position.x, 111, 0);
        //  main.active = false;
    }

    // Update is called once per frame

}
