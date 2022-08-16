using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    [SerializeField] float existTime;
    private void Start()
    {
        Destroy(gameObject, existTime);
    }
}
