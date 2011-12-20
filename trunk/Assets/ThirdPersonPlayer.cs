using UnityEngine;
using System.Collections;

public class ThirdPersonPlayer : MonoBehaviour
{
    //public AudioClip die;
    private int teamNo;
    // Use this for initialization
    void Start()
    {
        teamNo = networkView.group;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Fire");
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 100.0f))
        {
            Debug.Log("You shot: " + hit.transform.gameObject.name + " " + teamNo);
            hit.collider.SendMessage("ApplyDamage", SendMessageOptions.DontRequireReceiver);
        }
    }

    void ApplyDamage()
    {
        audio.Play();
    }
}
