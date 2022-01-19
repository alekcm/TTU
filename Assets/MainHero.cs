using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainHero : Creature
{
    public GameObject[] Items, Guns;
    public float RushDuration = 0.1f;
    public float RushSpeedMultiplier = 5;
    public Vector2 Direction;
    public Health HealthUI;
    public Weapon WearableWeapon;
    public Rigidbody2D RigidBody;
    public Room Room_Script;
    public GameObject Room_GameObject;
    public MainCamera MainCamera;
    private float x;
    private Vector2 position;
    public bool InCombat = false;

    public void Rush()
    {
        StartCoroutine(StartRush());
    }

    IEnumerator StartRush()
    {
        MoveSpeed *= RushSpeedMultiplier;
        yield return new WaitForSeconds(RushDuration);
        MoveSpeed /= RushSpeedMultiplier;
        yield break;
    }
    public void ChandeUIHealth()
    {
        HealthUI.TakeDamage(TakedDamage);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (MainCamera == null)
            MainCamera = GameObject.Find("Main Camera").GetComponent<MainCamera>();
        //x = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
             Direction != new Vector2(0, 0))
        {
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector2.left * MoveSpeed);

            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector2.right * MoveSpeed);

            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector2.up * MoveSpeed);

            if (Input.GetKey(KeyCode.S))
                transform.Translate(Vector2.down * MoveSpeed);

            transform.Translate(Direction * MoveSpeed);
        }
        else if (InCombat&&position!=new Vector2(0,0))transform.position = position;
         position= transform.position;
        /*if (x < transform.position.x)
            transform.localScale = new Vector3(1, transform.localScale.y, 0);
        else if (x > transform.position.x)
            transform.localScale = new Vector3(-1, transform.localScale.y, 0);
        x = transform.position.x;*/
        

        if (Room_GameObject == null)
        Room_GameObject = GameObject.FindGameObjectWithTag("Room");
        Room_Script = Room_GameObject.GetComponent<Room>();
        float count = 10000;
        GameObject NearestEnemy = new GameObject();
        foreach (Enemy enemy in Room_Script.Enemies)
        {
            float расстояние = ((gameObject.transform.position.x - enemy.gameObject.transform.position.x)*(gameObject.transform.position.x - enemy.gameObject.transform.position.x))+
                               ((gameObject.transform.position.y - enemy.gameObject.transform.position.y)*(gameObject.transform.position.y - enemy.gameObject.transform.position.y));
            Ray2D ray = new Ray2D(transform.position, enemy.transform.position);
            RaycastHit2D hit = Physics2D.Raycast(transform.position,enemy.transform.position, 10f);
            if (count > расстояние)
            {
                count = расстояние;
                NearestEnemy = enemy.gameObject;
            }
        }
        
        Vector2 Dir = gameObject.transform.position - NearestEnemy.transform.position;
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg-180f;
        RigidBody.rotation = angle;

    }

    public void Shoot()
    {
        WearableWeapon.Attack();
    }
    

    public void Die()
    {
        
    }
}
