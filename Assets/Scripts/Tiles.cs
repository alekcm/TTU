using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public Sprite[] Variants;
    public GameObject Room;

    public SpriteRenderer ThisSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (Variants.Length != 0)
        {
            ThisSpriteRenderer.sprite = Variants[Random.Range(0, Variants.Length)];
            transform.SetParent(Room.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
