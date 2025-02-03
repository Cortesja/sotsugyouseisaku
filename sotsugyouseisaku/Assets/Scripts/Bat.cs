using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private Transform player_;
    [SerializeField] private LayerMask whatIsGround_, whatIsPlayer_;

    [SerializeField] private float speed_ = 1f;

    //Patrolling
    [SerializeField] Vector3 walkPoint_;
    bool walkPointSet_;
    [SerializeField] float walkPointRange_;

    //Attacking
    [SerializeField] float timeBetweenAttacks_;
    bool alreadyAttacked_;

    //States
    [SerializeField] float sightRange_, attackRange_;
    [SerializeField] bool inSightRange_, inAttackRange_;

    private void Awake()
    {
        GameObject playerObj = GameObject.FindWithTag("Player"); // Make sure the Player has the correct tag
        if (playerObj != null)
        {
            player_ = playerObj.transform;
            Debug.Log("Player found: " + playerObj.name);
        }
        else
        {
            Debug.LogError("Player not found! Make sure the Player has the correct tag.");
        }
    }

    private void SearchForWalkPoint()
    {
        //Calculate Random point in range
        float randomZ = Random.Range(-walkPointRange_, walkPointRange_);
        float randomX = Random.Range(-walkPointRange_, walkPointRange_);

        walkPoint_ = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet_ = true;
        if (Physics.Raycast(walkPoint_, -transform.up, 2f, whatIsGround_)) { walkPointSet_ = true; }
    }
    void RotateTowardsMovement(Vector3 moveDirection)
    {
        if (moveDirection != Vector3.zero) // Prevent rotation when not moving
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    public void Parolling()
    {
        if (!walkPointSet_) { SearchForWalkPoint(); }

        float distance = Vector3.Distance(walkPoint_, transform.position);

        if (distance > attackRange_)
        {
            Vector3 direction = (walkPoint_ - transform.position).normalized;

            transform.position += direction * speed_ * Time.deltaTime;
            RotateTowardsMovement(-direction);
        }
        else
        {
            walkPointSet_ = false;
            SearchForWalkPoint();
        }
    }

    public void ChasePlayer()
    {
        //agent_.SetDestination(player_.position); //need to set the walkPoint to the player.position.
        walkPoint_ = player_.position;

        float distance = Vector3.Distance(walkPoint_, transform.position);

        if (distance > attackRange_)
        {
            Vector3 direction = (walkPoint_ - transform.position).normalized;

            transform.position += direction * speed_ * Time.deltaTime;
            RotateTowardsMovement(-direction);
        }
        if (distance > sightRange_)
        {
            walkPointSet_ = false;
            SearchForWalkPoint();
        }
    }


    public void AttackPlayer()
    {
        //Make sure enemy doesnt move
        //transform.position = Vector3.zero;
        transform.LookAt(player_);

        if (!alreadyAttacked_)
        {
            alreadyAttacked_ = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks_);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked_ = false;
    }

    private void Update()
    {
        //Check if player is in attack Range
        inSightRange_ = Physics.CheckSphere(transform.position, sightRange_, whatIsPlayer_);
        inAttackRange_ = Physics.CheckSphere(transform.position, attackRange_, whatIsPlayer_);

        if (!inSightRange_ && !inAttackRange_) { Parolling(); }
        if (inSightRange_ && !inAttackRange_) { ChasePlayer(); }
        if (inSightRange_ && inAttackRange_) { AttackPlayer(); }
    }
}
