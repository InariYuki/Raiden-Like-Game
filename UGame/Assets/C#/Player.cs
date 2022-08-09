using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float min_x, max_x, min_y, max_y;
    private void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5f , 0 , Input.GetAxisRaw("Vertical") * Time.deltaTime * 5f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_x, max_x), Mathf.Clamp(transform.position.y, min_y, max_y) , transform.position.z);
    }
}
