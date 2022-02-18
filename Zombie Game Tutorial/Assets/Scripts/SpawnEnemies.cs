using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject agentPrefab;

    public int numZombies = 10;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numZombies; i++)
        {
            Instantiate(agentPrefab, new Vector3(0, 2, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
