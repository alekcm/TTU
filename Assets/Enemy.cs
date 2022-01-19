using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Creature
{
    public AIDestinationSetter Setter;
    public AIPath AiPath;
    public GameObject[] Sprites;
    public GameObject DeathSprite;
    public bool alive = true;
    public int Cost;
    public Rigidbody2D WeaponRigidBody;
    private Room Room_Script;
    public CircleCollider2D[] BoxCollider;
    private GameObject Player;
    public GameObject DropableItem, NextPhase;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.rotation.z != 0)
            transform.rotation = new Quaternion(0, 0, 0, 0);
        StyleRank = FindObjectOfType<StyleRank>();
        Player = GameObject.Find("Main Hero");
        Setter.target = Player.transform;
        GameObject Room = GameObject.FindGameObjectWithTag("Room");
        transform.SetParent(Room.transform);
        Room_Script = Room.GetComponent<Room>();
        Room_Script.Enemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Dir = gameObject.transform.position - Player.transform.position;
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg-180f;
        WeaponRigidBody.rotation = angle;
    }

    public void DropItem()
    {
        GameObject Item = Instantiate(DropableItem, transform.position, Quaternion.identity);
        Item.transform.parent = transform.parent;
    }

    public void ChangePhase()
    {
        GameObject NewPhase = Instantiate(NextPhase, transform.position, Quaternion.identity);
        NewPhase.transform.parent = transform.parent;
        Destroy(gameObject);
    }
    
    public void DieForever()
    {
        
        Room_Script.Enemies.Remove(this);
        Room_Script.CurrentPoints -= Cost;
        if (Room_Script.Waves > 0&&Room_Script.CurrentPoints < Room_Script.MinPoints)
            Room_Script.SummonNewWave();
            else if (Room_Script.Enemies.Count == 0)
            {
                Room_Script.EndBattle();
            }
        

        for (int i = 0; i < BoxCollider.Length; i++)
        {
            BoxCollider[i].enabled = false;
        }

        alive = false;
        for (int i = 0; i < Sprites.Length; i++)
        {
            Sprites[i].SetActive(false);
        }
        DeathSprite.SetActive(true);
        AiPath.enabled = false;
    }

    
    
}
