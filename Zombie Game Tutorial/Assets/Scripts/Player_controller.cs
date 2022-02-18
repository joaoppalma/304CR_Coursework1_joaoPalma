using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_controller : MonoBehaviour
{
    Vector3 target;
    NavMeshAgent agent;
    Animator anim;
    List<Rigidbody> allRbs;

    // Start is called before the first frame update
    void Start()
    {
        allRbs = new List<Rigidbody>();
        allRbs.AddRange(GetComponentsInChildren<Rigidbody>());
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        foreach (Rigidbody rb in allRbs)
        {
            rb.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }

        GetInputs();
        PlayAnimations();
    }
    
    public void Die()
    {
        foreach (Rigidbody rb in allRbs)
        {
            rb.isKinematic = false;
        }
        anim.enabled = false;
        agent.isStopped = true;
    }


    private void GetInputs()
    {
        // Player movement by click and point
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                agent.SetDestination(hit.point);
            }
        }

    }

    private void PlayAnimations()
    {
        anim.SetFloat("toward", agent.velocity.magnitude);
    }
}
