using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotationStablasing : MonoBehaviour
{
    private Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = StartPosition;
        if (gameObject.transform.rotation.z <-0.7f)
            gameObject.transform.localScale = new Vector3(1,-1,1);
        else gameObject.transform.localScale = new Vector3(1,1,1);
    }
}
