using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlsFather : MonoBehaviour
{
    public Vector2 PlaceWhereITakeDamage;
    public Rigidbody2D Rigidbody2D;
    // Start is called before the first frame update
    public void Change()
    {
        Vector2 Dir = new Vector2(transform.position.x,transform.position.y) - PlaceWhereITakeDamage;
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg-180f;
        Rigidbody2D.rotation = angle+90;
    }
    
}
