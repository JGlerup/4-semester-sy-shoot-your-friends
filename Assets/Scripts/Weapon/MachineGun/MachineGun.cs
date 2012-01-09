using UnityEngine;
using System.Collections;

public class MachineGun : MonoBehaviour {
    public float range = 100.0f;
    public float fireRate = 0.05f;
    public float force = 10.0f;
    public float damage = 5.0f;
    public int bulletsPerClip = 40;
    public int clips = 20;
    public int maxClips = 20;
    public int reloadTime = 3;
    private ParticleEmitter hitParticles;
    public Renderer muzzleFlash;
    private HUD hud;

    private int bulletsLeft = 0;
    private float nextFireTime = 0.0f;
    private int m_LastFrameShot = -1;

	// Use this for initialization
	void Start () {
        hitParticles = (ParticleEmitter)GetComponentInChildren(typeof(ParticleEmitter));

        if (hitParticles)
            hitParticles.emit = false;
        bulletsLeft = bulletsPerClip;
        UpdateAmmoGUI();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (muzzleFlash)
        {
            if (m_LastFrameShot == Time.frameCount)
            {
                muzzleFlash.transform.localRotation = Quaternion.AngleAxis(Random.value * 360, Vector3.forward);
                muzzleFlash.enabled = true;

                if (audio)
                {
                    if (!audio.isPlaying)
                        audio.Play();
                    //Debug.Log("Play");
                    audio.loop = true;
                }
            }
            else
            {
                muzzleFlash.enabled = false;
                enabled = false;

                if (audio)
                {
                    audio.loop = false;
                }
            }
        }

	}

    void Fire()
    {
        if (bulletsLeft == 0)
            return;
        if (Time.time - fireRate > nextFireTime)
            nextFireTime = Time.time - Time.deltaTime;

        while (nextFireTime < Time.time && bulletsLeft != 0)
        {
            networkView.RPC("FireOneShot", RPCMode.All, null);
            nextFireTime += fireRate;
        }
    }

    [RPC]
    void FireOneShot()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, range))
        {
            if (hit.rigidbody)
                hit.rigidbody.AddForceAtPosition(force * direction, hit.point);

            if (hitParticles)
            {
                hitParticles.transform.position = hit.point;
                hitParticles.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                hitParticles.Emit();
            }

            string teamTag = gameObject.transform.parent.parent.parent.tag;
            //Debug.Log(teamTag);
            if (hit.collider.tag != teamTag)
            {
                hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }

        //bulletsLeft--;
        //UpdateAmmoGUI();
        m_LastFrameShot = Time.frameCount;
        enabled = true;

        if (bulletsLeft == 0)
            Reload();
    }

    public void UpdateAmmoGUI()
    {
        GameObject go = GameObject.Find("GUI");
        hud = (HUD)go.GetComponent(typeof(HUD));
        //hud.UpdateGUIAmmo(bulletsLeft);
    }

    void Reload() {
        //yield return new WaitForSeconds(0.1f);

        if (clips > 0)
        {
            clips--;
            bulletsLeft = bulletsPerClip;
        }
    }

}
