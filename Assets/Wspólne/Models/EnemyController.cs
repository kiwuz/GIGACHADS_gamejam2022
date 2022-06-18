using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public delegate void Death(GameObject enemyType,EnemyController enemy);
    public event Death OnDeath;

    [SerializeField]
    Collider playercollider;
    [SerializeField]
    Collider mothercollider;

    [HideInInspector]
    public NavMeshAgent navMesh;
    [SerializeField]
    private Transform eyesPosition;
    [SerializeField]
    private Transform PlayerHead;

    private bool seePlayer;
    private bool playerInAttackRange;
    private bool playerInStoppingDistance;

    public EnemyData enemyModel;

    [SerializeField]
    private float waitTime=1;

    private Animator animator;
    private float detectionRadius { get { return enemyModel.detectionRadius; } }
    private float attackRange { get { return enemyModel.attackRange; } }
    private LayerMask layerMask { get { return enemyModel.layerMask; } }
    public Transform playerTransform { get { return enemyModel.playerTransform; } set { enemyModel.playerTransform = value; } }
    public Transform motherTransform { get { return enemyModel.motherTransform; } set { enemyModel.motherTransform = value; } }
    private float maxHealth { get { return enemyModel.maxHealth; } }


    [SerializeField]
    private float currentHealth;
    
    [SerializeField] public float currentPhysicalDMG;
    [SerializeField] public float currentMagicalDMG;
    [SerializeField] public float currentPhysicalArmor;
    [SerializeField] public float currentMagicalArmor;

    [SerializeField] public int experienceOnDeath;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<Camera>().transform;
       motherTransform= GameObject.Find("MamaDino").transform;

        //Debug.Log(playerTransform);
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.stoppingDistance = enemyModel.stoppingDistance;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        StartCoroutine("CheckStatus");
    }
    private IEnumerator CheckStatus()
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            CheckPlayerStatus();
            CheckEnemyStatus();
        }        
    }
    private void CheckPlayerStatus()
    {
        CheckPlayerVisible();
        //if (seePlayer)
        //{
        //    CheckPlayerIsInRange();
        //    waitTime = 1;
        //}
        //else
        //{
        //    waitTime = 5;
        //}

        SetBools();
    }
    private void CheckPlayerVisible()
    {
        if (Physics.OverlapSphere(transform.position, detectionRadius, layerMask).Length > 0)
        {
            List<Collider> colliders = new List<Collider>(Physics.OverlapSphere(transform.position, detectionRadius, layerMask));
            if (colliders.Contains(playercollider))
            {
                animator.SetBool("PlayerInRange", true);
            }
            else
            {
                animator.SetBool("PlayerInRange", false);
            }
            if (colliders.Contains(mothercollider))
            {
                animator.SetBool("MotherInRange", true);
                //animator.SetBool("PlayerInRange", false);
            }
            else
            {
                animator.SetBool("MotherInRange", false);
            }



            //Debug.Log("wykryto colider gracza");
            //wykryto collider gracza
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(eyesPosition.position, playerTransform.position - eyesPosition.position, out hit);
            Debug.DrawRay(eyesPosition.position, playerTransform.position  - eyesPosition.position,Color.red,detectionRadius+5);
            if (hit.collider == null) return;
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                seePlayer = true;
                //Debug.Log("widzi gracza");
            }
            else
            {
                seePlayer = false;
                //Debug.Log("nie widze gracza");
            }
        }
        else
        {
            seePlayer = false;
        }

    }
    private void CheckPlayerIsInRange()
    {
        float distanceBetweenPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceBetweenPlayer < attackRange)
        {
            playerInAttackRange = true;
        }
        else
        {
            playerInAttackRange = false;
        }

        if (distanceBetweenPlayer <= navMesh.stoppingDistance)
        {
            playerInStoppingDistance = true;
        }
        else
        {
            playerInStoppingDistance = false;
        }

    }
    private void SetBools()
    {
        animator.SetBool("seePlayer", seePlayer);
        animator.SetBool("playerInAttackRange",playerInAttackRange);
        animator.SetBool("playerInStoppingDistance", playerInStoppingDistance);
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    private void CheckEnemyStatus()
    {
        if (currentHealth <= 0)
        {
            animator.SetBool("isAlive", false);
        }
    }






}
