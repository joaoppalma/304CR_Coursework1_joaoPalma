using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour
{
    Rigidbody bullet;

    private void Start()
    {
        bullet = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other);
            Debug.Log("here");
        }

        Destroy(this);
    }
}