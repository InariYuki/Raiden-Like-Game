using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float min_x, max_x, min_y, max_y;
    float speed = 5f;
    bool mouse_down = false;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform muzzle;
    bool can_fire = true;
    private void Update()
    {
        /*if (Input.GetKey(StaticVars.keyboard_ctl[0]))
        {
            transform.Translate(0 , 0 , speed * Time.deltaTime);
        }
        else if (Input.GetKey(StaticVars.keyboard_ctl[1]))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(StaticVars.keyboard_ctl[2]))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(StaticVars.keyboard_ctl[3]))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }*/
#if UNITY_STANDALONE_WIN
        transform.Translate(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed);
#endif
#if UNITY_ANDROID
        transform.Translate(Input.acceleration.x * Time.deltaTime * speed , 0 , Input.acceleration.y * Time.deltaTime * speed);
#endif
        if (mouse_down)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -1f);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, min_x, max_x), Mathf.Clamp(transform.position.y, min_y, max_y), transform.position.z);
        if (can_fire)
        {
            can_fire = false;
            Instantiate(bullet , muzzle.position , Quaternion.identity);
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(1f);
        can_fire = true;
    }
    private void OnMouseDown()
    {
        mouse_down = true;
    }
    private void OnMouseUp()
    {
        mouse_down = false;
    }
}
