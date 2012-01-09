using UnityEngine;
using System.Collections;

public class ZombieAttackWeapon : MonoBehaviour {
    public float reloadTime = 0.5f;
    public float lastShot = -10.0f;
    public int damage = 6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Fire()
    {
        networkView.RPC("Attack", RPCMode.All, null);
    }

    [RPC]
    void Attack()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, 2.0f))
        {
            if (Time.time > reloadTime + lastShot)
            {
                //hit.collider.SendMessageUpwards("ApplyDamage", hit.transform.position, SendMessageOptions.DontRequireReceiver);
                hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
                lastShot = Time.time;

            }
        }
    }
}
