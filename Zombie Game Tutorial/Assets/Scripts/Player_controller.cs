using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_controller : MonoBehaviour
{
    Vector3 target;
    NavMeshAgent agent;
    Animator anim;
    List<Rigidbody> allRbs;

    public GameObject gunPos;
    public GameObject bullet;
    GameObject message;

    public float fireForce = 20f;
    

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        allRbs = new List<Rigidbody>();
        allRbs.AddRange(GetComponentsInChildren<Rigidbody>());
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        message = GameObject.FindGameObjectWithTag("UI");

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

        isDead = true;
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

        if (Input.GetMouseButtonDown(1))
        {
            GameObject projectile = Instantiate(bullet, gunPos.transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().AddForce(gunPos.transform.up * fireForce, ForceMode.Impulse);
        }

        // keyboard inputs
        if (Input.GetKey(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            isDead = false;
        }
    }

    private void PlayAnimations()
    {
        anim.SetFloat("toward", agent.velocity.magnitude);
    }
}
