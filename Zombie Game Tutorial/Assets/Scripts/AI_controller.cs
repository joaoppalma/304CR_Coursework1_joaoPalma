using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_controller : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    //public Transform player;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player"); // Find the game object with the tag Player
        StartCoroutine(SetTarget());
    }

    private void Update()
    {
        if (player.GetComponent<Player_controller>().isDead == true)
        {
            agent.isStopped = true;
            anim.enabled = false;
        }
        else
        {
            Animations();
        }
    }

    private void Animations()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 1.5f)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
            anim.SetBool("isIdle", false);

            anim.speed = 1f;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) > 1f)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isIdle", false);

            anim.speed = 2.5f;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.speed = agent.velocity.magnitude / 2f;
        }
    }

    // Update is called once per frame
    IEnumerator SetTarget()
    {
        yield return new WaitForSeconds(1f);
        agent.SetDestination(player.transform.position);
        StartCoroutine(SetTarget());
    }
}
