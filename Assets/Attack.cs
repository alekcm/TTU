using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Vector3 StartPosition;
    public Rigidbody2D RigidBody;
    public Transform Player;
    public Animator animator;

    public Weapon[] weapon;
    // Start is called before the first frame update

    void Start()
    {
        StartPosition = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localPosition = new Vector3(0,0,0);
        if (Player != null)
        {
            Vector2 Dir = gameObject.transform.position - Player.position;
            float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg - 180f;
            RigidBody.rotation = angle;
            for(int i = 0; i < weapon.Length; i++)
                if (weapon[i].AllowToShoot)
                {   
                    animator.Play("Attack");
                    weapon[i].Attack();
                }
        }

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player" && !collider2D.isTrigger)
            Player = collider2D.gameObject.transform;
    }
    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player" && !collider2D.isTrigger)
            Player = null;
    }
}
