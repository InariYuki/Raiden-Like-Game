using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed , destroyTime , shootInterval , collisionDamage;
    [SerializeField] GameObject bullet , explosion;
    [SerializeField] Transform muzzle;
    Player player;
    SpawnEnemy GM;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        GM = FindObjectOfType<SpawnEnemy>();
    }
    private void Start()
    {
        Destroy(gameObject , destroyTime);
        if (gameObject.tag == "Enemy")
        {
            InvokeRepeating("Shoot" , shootInterval , shootInterval);
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
    }
    void Shoot()
    {
        Instantiate(bullet , muzzle.position , Quaternion.Euler(0 , 0 , 180));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            GM.Hit(collisionDamage);
            GM.AddScore(-200);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
