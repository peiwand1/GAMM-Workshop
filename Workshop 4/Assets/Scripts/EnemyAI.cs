using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent enemy;


    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }


}