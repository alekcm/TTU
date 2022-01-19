using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Animator animator;
    private float Size;
    private float x,y;
    
    // Start is called before the first frame update
    void Start()
    {
        Size = transform.localScale.x;
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (x < transform.position.x)
            transform.localScale = new Vector3(Size, transform.localScale.y, 0);
        else if (x > transform.position.x)
            transform.localScale = new Vector3(-Size, transform.localScale.y, 0);
            if (x != transform.position.x || y != transform.position.y){
                animator.Play("Walk");
                    x = transform.position.x;
                    y = transform.position.x;
                    }
            else
            {
                animator.Play("Idle");
            }
    }
}
