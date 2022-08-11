using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject[] enemies = new GameObject[0];
    float spawn_interval = 2f;
    private void Start()
    {
        InvokeRepeating("Spawn" , spawn_interval , spawn_interval);
    }
    void Spawn()
    {
        Instantiate(enemies[Random.Range(0 , enemies.Length)] , transform.position + new Vector3(Random.Range(-2.4f , 2.4f) , 0 , 0) , Quaternion.Euler(90 , 0 , 180));
    }
}
