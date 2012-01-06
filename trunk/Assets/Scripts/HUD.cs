using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    private string health;
    private string ammo;

    void Start()
    {
        this.enabled = false;
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10.0f, 10.0f, 100.0f, 20.0f), "Health: " + health);
        //GUI.color = Color.blue;
        //GUI.Label(new Rect(10.0f, 30.0f, 100.0f, 20.0f), "Ammo: " + ammo);
    }

    public void UpdateGUIHealth(int health)
    {
        this.health = health.ToString();
    }

    //public void UpdateGUIAmmo(int ammo)
    //{
    //    this.ammo = ammo.ToString();
    //}
}