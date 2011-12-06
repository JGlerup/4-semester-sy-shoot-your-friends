using UnityEngine;
using System.Collections;


public enum AIState { Chase, Attack }

public class ZombieAI : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float distance;
    public float reloadTime;
    public float lastShot;

    private Transform target;
    private AIState state;

    // Use this for initialization
    private void Start()
    {
        moveSpeed = 5.0f;
        rotationSpeed = 5.0f;
        reloadTime = 0.5f;
        lastShot = -10.0f;
        target = GameObject.FindWithTag("Player").transform;
        state = AIState.Chase;
    }

    // Update is called once per frame
    private void Update()
    {
        MakeDecision();
    }

    private void MakeDecision()
    {
        switch (state)
        {
            case AIState.Chase:
                ChasePlayer();
                break;
            case AIState.Attack:
                AttackPlayer();
                break;
        }
    }

    /// <summary>
    /// Denne metode tjekker afstanden mellem objektet selv (fjenden) og spilleren.
    /// Hvis afstanden mellem disse er 10, påføres der skade på spilleren
    /// </summary>
    private void AttackPlayer()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            if (Time.time > reloadTime + lastShot)
            {
                hit.transform.SendMessageUpwards("ApplyDamage", 5.0f, SendMessageOptions.DontRequireReceiver);
                lastShot = Time.time;
                transform.renderer.material.color = Color.red;
            }
        }
        else
        {
            state = AIState.Chase;
        }
        LookAtPlayer();
    }

    private void ChasePlayer()
    {
        CharacterController cc = (CharacterController)gameObject.GetComponent(typeof(CharacterController));
        distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance > 10.0f)
        {
            LookAtPlayer();
            cc.Move(transform.forward * moveSpeed * Time.deltaTime);
            transform.renderer.material.color = Color.gray;
        }
        else
        {
            state = AIState.Attack;
        }
    }

    private void LookAtPlayer()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
    }
}

