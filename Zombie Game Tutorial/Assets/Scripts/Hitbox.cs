using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<Player_controller>() != null)
        {
            Debug.Log("Ere");
            other.GetComponentInParent<Player_controller>().Die();
        }
    }
}
