using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    private string health;
    private string ammo;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10.0f, 10.0f, 100.0f, 20.0f), "Health: " + health);
        GUI.color = Color.blue;
        GUI.Label(new Rect(10.0f, 30.0f, 100.0f, 20.0f), "Ammo: " + ammo);
        GUI.color = Color.white;
        int guiTime = (int)(Time.time - startTime);
        int minutes = guiTime / 60;
        int seconds = guiTime % 60;

        string textTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        GUI.Label(new Rect(10.0f, 60.0f, 100.0f, 20.0f), textTime);
    }

    public void UpdateGUIHealth(int health)
    {
        this.health = health.ToString();
    }

    public void UpdateGUIAmmo(int ammo)
    {
        this.ammo = ammo.ToString();
    }
}