using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    public float explosionRadius; //Default 5.0f
    public float explosionForce; //Default 10.0f
    public float explosionDamage; //Default 100.0f


    // Use this for initialization
    void Start()
    {
        explosionRadius = 5.0f;
        explosionForce = 10.0f;
        explosionDamage = 100.0f;
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            Vector3 closestPoint = hit.ClosestPointOnBounds(explosionPosition);
            float distance = Vector3.Distance(closestPoint, explosionPosition);
            float hitPoints = 1.0f - Mathf.Clamp01(distance / explosionRadius);
            hitPoints *= explosionDamage;
            hit.SendMessageUpwards("ApplyDamage", hitPoints, SendMessageOptions.DontRequireReceiver);
        }
        colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.rigidbody)
            {
                hit.rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 3.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}