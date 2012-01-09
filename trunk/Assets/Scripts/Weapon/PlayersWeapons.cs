using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayersWeapons : MonoBehaviour
{
    private List<GameObject> weaponList;
    private int selectedWeapon; //For at holde styr p� hvilket v�ben spilleren har valgt

    // Use this for initialization
    private void Start()
    {
        SetupWeapons();
        SelectWeapon(0);
        selectedWeapon = 0;
    }

    /// <summary>
    /// Tilf�jer alle v�ben til en liste, s�ledes at tilgangen er nemmere
    /// </summary>
    private void SetupWeapons()
    {
        weaponList = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            weaponList.Add(transform.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (networkView.isMine)
        {
            if (Input.GetButton("Fire1"))
                BroadcastMessage("Fire");
            //MachineGun
            if (Input.GetKeyDown("1"))
            {
                //SelectWeapon(0);
                networkView.RPC("SelectWeapon", RPCMode.All, 0);
                MachineGun mg = (MachineGun)weaponList[0].GetComponentInChildren(typeof(MachineGun));
                mg.UpdateAmmoGUI();
                selectedWeapon = 0;
            }
            //RocketLauncher
            if (Input.GetKeyDown("2"))
            {
                //SelectWeapon(1);
                networkView.RPC("SelectWeapon", RPCMode.All, 1);
                RocketLauncher rl = (RocketLauncher)weaponList[1].GetComponentInChildren(typeof(RocketLauncher));
                rl.UpdateGUIAmmo();
                selectedWeapon = 1;
            }
        }
    }

    [RPC]
    private void SelectWeapon(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            // Aktivere det valgte v�ben
            if (i == index)
            {
                weaponList[i].SetActiveRecursively(true);
                selectedWeapon = i;
            }
            // Deaktivere alle andre v�ben
            else
            {
                weaponList[i].gameObject.SetActiveRecursively(false);
            }
        }

    }

    /// <summary>
    /// Denne metode giver maks. ammunition til alle v�ben.
    /// Alle v�ben aktiveres (for at undg� NullReferenceException)
    /// og deres nuv�rende ammunition s�ttes til maks.
    /// Til sidst aktiveres det v�ben som spilleren har valgt
    /// </summary>
    public void ApplyAmmo()
    {
        foreach (GameObject weapon in weaponList)
            weapon.SetActiveRecursively(true);
        MachineGun mg = (MachineGun)weaponList[0].GetComponentInChildren(typeof(MachineGun));
        mg.clips = mg.maxClips;
        RocketLauncher rl = (RocketLauncher)weaponList[1].GetComponentInChildren(typeof(RocketLauncher));
        rl.ammoCount = rl.maximumAmmoCount;
        SelectWeapon(selectedWeapon);
    }
}
