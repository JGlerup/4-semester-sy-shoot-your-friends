using UnityEngine;
using System.Collections;

public enum PickupType
{
    Health, Ammo
}

public class Pickup : MonoBehaviour
{
    private PickupType pickupType;
    public AudioClip ammoPickupSound;
    public AudioClip healthPickupSound;

    // Use this for initialization
    private void Start()
    {
        pickupType = PickupType.Ammo;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up * 100.0f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            ApplyPickUp();
            Destroy(gameObject);
        }
    }

    private void ApplyPickUp()
    {
        switch (pickupType)
        {
            case PickupType.Ammo:
                UpdateAmmo();
                break;
            case PickupType.Health:
                UpdateHealth();
                break;
        }
    }

    private void UpdateAmmo()
    {
        AudioSource.PlayClipAtPoint(ammoPickupSound, transform.position);
        GameObject go = GameObject.Find("Weapons");
        PlayersWeapons playerWeapon = (PlayersWeapons)go.GetComponent(typeof(PlayersWeapons));
        playerWeapon.ApplyAmmo();
    }

    private void UpdateHealth()
    {
        GameObject go = GameObject.Find("First Person Controller");
        FPSPlayer fpsPlayer = (FPSPlayer)go.GetComponent(typeof(FPSPlayer));
        fpsPlayer.ApplyHealth();
    }
}
