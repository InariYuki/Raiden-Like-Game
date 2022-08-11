using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float dead_time = 3f , speed = 10f;
    private void Start()
    {
        Destroy(gameObject, dead_time);
    }
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
