using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum AIState { Chase, Attack, ScanForTarget}

public class ZombieAI : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float distance;
    public float reloadTime;
    public float lastShot;
    //public float attackRange = 2.0f;
    public AnimationClip walkAnimation;
    public AnimationClip attackAnimation;
    private Animation animation;

    private Transform target;
    private AIState state;

    // Use this for initialization
    private void Start()
    {
        animation = (Animation)GetComponent(typeof(Animation));
        moveSpeed = 5.0f;
        rotationSpeed = 5.0f;
        reloadTime = 0.5f;
        lastShot = -10.0f;
        target = null;
        state = AIState.ScanForTarget;
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
            case AIState.ScanForTarget:
                ScanForTarget();
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
        if (Physics.Raycast(transform.position, fwd, out hit, 2.0f))
        {
            if (Time.time > reloadTime + lastShot)
            {
                hit.transform.SendMessageUpwards("ApplyDamage", hit.transform.position, SendMessageOptions.DontRequireReceiver);
                lastShot = Time.time;
                //transform.renderer.material.color = Color.red;
                //animation[attackAnimation.name].speed = 1.0f;
                //Debug.Log(attackAnimation.name);
                animation.Play(attackAnimation.name);
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
        if (distance > 2)
        {
            LookAtPlayer();
            cc.Move(transform.forward * moveSpeed * Time.deltaTime);
            //animation[walkAnimation.name].speed = 1.0f;
            //Debug.Log(walkAnimation.name);
            animation.Play(walkAnimation.name);
            //transform.renderer.material.color = Color.gray;
        }
        else
        {
            state = AIState.Attack;
        }
    }

    private void ScanForTarget()
    {
        target = GetClosestPlayer();
        if (target == null)
        {
            state = AIState.ScanForTarget;
        }
        else
        {
            state = AIState.Chase;
        }
    }

    private Transform GetClosestPlayer()
    {
        List<GameObject> listOfPlayer = new List<GameObject>();
        listOfPlayer.AddRange(GameObject.FindGameObjectsWithTag("team1"));
        listOfPlayer.AddRange(GameObject.FindGameObjectsWithTag("team2"));
        listOfPlayer.AddRange(GameObject.FindGameObjectsWithTag("team3"));
        listOfPlayer.AddRange(GameObject.FindGameObjectsWithTag("team4"));
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject go in listOfPlayer)
        {
            Transform t = go.transform;
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }

    private void LookAtPlayer()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
        //transform.LookAt(target);
    }
}

