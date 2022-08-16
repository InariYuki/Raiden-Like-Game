using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject playerExplode, enemyExplode, asteroidExplode;
    [SerializeField] float damage;
    SpawnEnemy GM;
    public enum BulletType
    {
        player,
        enemy
    }
    public BulletType bulletType;
    float dead_time = 3f, speed = 10f;
    private void Awake()
    {
        GM = FindObjectOfType<SpawnEnemy>();
    }
    private void Start()
    {
        Destroy(gameObject, dead_time);
    }
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (bulletType)
        {
            case BulletType.player:
                if (other.tag == "Enemy" || other.tag == "Asteroid")
                {
                    if (other.tag == "Enemy")
                    {
                        Instantiate(enemyExplode, other.transform.position, Quaternion.identity);
                        GM.AddScore(10);
                    }
                    else
                    {
                        Instantiate(asteroidExplode, other.transform.position, Quaternion.identity);
                        GM.AddScore(1);
                    }
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
                break;
            case BulletType.enemy:
                if (other.tag == "Player")
                {
                    FindObjectOfType<SpawnEnemy>().Hit(damage);
                    Instantiate(playerExplode, other.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    GM.AddScore(-100);
                }
                break;
        }
    }
}
