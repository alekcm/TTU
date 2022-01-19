using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsList : MonoBehaviour
{
    public GameObject Player, Camera;
    public GameObject[] RoomList;
    // Start is called before the first frame update
    void Start()
    {
        GoToRandomLocation();
    }

    public void GoToRandomLocation()
    {
        GoToLocation(Random.Range(0,RoomList.Length));
    }
    public void GoToLocation(int id)
    {
        while (RoomList[id] == null)
        {
            id++;
            if (id == RoomList.Length - 1)
                id = 0;
        }

        
        for (int i = 0; i <RoomList.Length; i++)
            if (RoomList[i]!=null)
            if (RoomList[i].active)
                RoomList[i].SetActive(false);
        Player.GetComponent<MainHero>().InCombat = false;
        Player.transform.position = RoomList[id].GetComponent<Room>().PlayerSpawn.position;
        Player.GetComponent<MainHero>().InCombat = true;
        Camera.transform.position = RoomList[id].GetComponent<Room>().PlayerSpawn.position;
        RoomList[id].SetActive(true);
        RoomList[id].GetComponent<Room>().SummonNewWave();
        RoomList[id] = null;
    }
}
