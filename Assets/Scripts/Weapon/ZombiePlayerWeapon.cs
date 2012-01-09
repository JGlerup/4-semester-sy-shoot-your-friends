using UnityEngine;
using System.Collections;

public class ZombiePlayerWeapon : MonoBehaviour
{
    public AnimationClip attackAnimation;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (networkView.isMine)
        {
            if (Input.GetButton("Fire1"))
            {
                BroadcastMessage("Fire");
                //SelectWeapon(0);
                animation.Play(attackAnimation.name);
            }
        }
    }


}
