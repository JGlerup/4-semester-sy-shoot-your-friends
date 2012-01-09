using UnityEngine;
using System.Collections;

public class RocketLauncher : MonoBehaviour
{
    public Rigidbody projectile;
    public float speed;
    public float reloadTime;
    public int ammoCount;
    public int maximumAmmoCount;
    public float lastShot;
    public HUD hud;

    // Use this for initialization
    void Start()
    {
        speed = 20.0f;
        ammoCount = 20;
        reloadTime = 0.5f;
        lastShot = -10.0f;
        maximumAmmoCount = 20;
        UpdateGUIAmmo();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Fire()
    {
        if (Time.time > reloadTime + lastShot && ammoCount > 0)
        {
            //networkView.RPC("InstantiateMissile", RPCMode.All, null);
            InstantiateMissile();
            //ammoCount--;
            //UpdateGUIAmmo();
            lastShot = Time.time;
        }
    }

    //[RPC]
    void InstantiateMissile()
    {
        //Rigidbody instantiatedProjectile = (Rigidbody)Instantiate(projectile, transform.position, transform.rotation);
        Rigidbody instantiatedProjectile = (Rigidbody)Network.Instantiate(projectile, transform.position, transform.rotation, 0);
        //instantiatedProjectile.transform.Translate(0, 0.15f, 0.8f, Space.Self);
        //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        Physics.IgnoreCollision(instantiatedProjectile.collider, transform.root.collider);
    }

    public void UpdateGUIAmmo()
    {
        GameObject go = GameObject.Find("GUI");
        hud = (HUD)go.GetComponent(typeof(HUD));
        //hud.UpdateGUIAmmo(ammoCount);
    }
}
