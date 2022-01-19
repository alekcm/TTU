using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Transform Player;
    public int Speed = 100;
    void Update()
    {
        if (Player != null)
        {
            if (Speed>10)
            Speed -= 1;
            Vector2 Dir = Player.position - gameObject.transform.position;
            transform.Translate(Dir/Speed);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player" && !collider2D.isTrigger)
        {
            Player = collider2D.gameObject.GetComponent<Transform>();
        }
    }
    
}
