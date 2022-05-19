using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private Transform player;
    private float distance;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float distFromPlayer;
    [SerializeField] private float distFromPlayerAttack;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        distance = Vector3.Distance(player.position, transform.position);

        if (distance <= distFromPlayer && distance > distFromPlayerAttack)
        {
            transform.LookAt(player.position + new Vector3(0, 0, 5));
            anim.SetBool("Walk Forward", true);
            anim.SetBool("Attack", false);
            GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        }

        if (distance <= distFromPlayerAttack)
        {
            anim.SetBool("Walk Forward", false);
            anim.SetBool("Attack", true);
        }

        if(distance > distFromPlayer)
        {
            anim.SetBool("Walk Forward", false);
            anim.SetBool("Attack", false);
        }
    }
}
