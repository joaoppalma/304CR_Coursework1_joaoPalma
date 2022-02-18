using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject agentPrefab;

    GameObject player;

    int numZombies = 5;
    float delay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < numZombies; i++)
        {
            Instantiate(agentPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        }

        InvokeRepeating("SpawnZombie", delay, delay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnZombie()
    {
        if (player.GetComponent<Player_controller>().isDead == false)
        {
            for (int i = 0; i < numZombies; i++)
            {
                Instantiate(agentPrefab, new Vector3(0, 2, 0), Quaternion.identity);
            }
        }
        else
        {

        }
        
    }
}
