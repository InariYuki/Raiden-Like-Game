using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    Control input;
    float speed = 5f;
    public float min_x, max_x, min_y, max_y;
    private void Awake()
    {
        input = new Control();
        input.Enable();
    }
    private void Update()
    {
        Vector2 move = input.Player.Movement.ReadValue<Vector2>();
        transform.Translate(move.x * speed * Time.deltaTime , 0 , move.y * speed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_x, max_x), Mathf.Clamp(transform.position.y, min_y, max_y), transform.position.z);
    }
}
