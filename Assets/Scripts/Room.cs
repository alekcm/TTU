using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

public class Room : MonoBehaviour
{
    public RoomsList RoomsList;
    public Transform PlayerSpawn;
    public Transform[] EnemySpawnPoint;
    public GameObject[] ListOfProbablyEnemies;
    public int Points, MinPoints, Waves, CurrentPoints;
    private int min;
    public List<Enemy> Enemies;
    public UnityEvent EndOfBattleEvent;
    public GameObject _spawner;
    void Start()
    {
            int min=100;
            for (int i = 0; i < ListOfProbablyEnemies.Length; i++)
            {
                Enemy enemy = ListOfProbablyEnemies[i].GetComponent<Enemy>();
                if (enemy.Cost < min)
                    min = enemy.Cost;
            }
    }
    public void GoToNewRoom()
    {
        RoomsList.GoToRandomLocation();
    }
    public void SummonNewWave()
    {
        CurrentPoints = Points;
        while (CurrentPoints >= min)
        {
            int Id = Random.Range(0, ListOfProbablyEnemies.Length);
            Enemy NewEnemy= ListOfProbablyEnemies[Id].GetComponent<Enemy>();
            Instantiate(_spawner,EnemySpawnPoint[Random.Range(0,EnemySpawnPoint.Length)].position, Quaternion.identity);
            Spawner _spawn = _spawner.GetComponent<Spawner>();
            _spawner.transform.parent = gameObject.transform;
            _spawn.Enemy = ListOfProbablyEnemies[Id];
            CurrentPoints -= NewEnemy.Cost;
        }

        Waves--;
        CurrentPoints = Points;
    }

    public void EndBattle()
    {
        EndOfBattleEvent.Invoke();
    }

}
