using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_controller : MonoBehaviour
{
    GameObject player;

    public Text message;   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player_controller>().isDead == true)
        {
            message.enabled = true;
        }
        else
        {
            message.enabled = false;
        }
    }
}
