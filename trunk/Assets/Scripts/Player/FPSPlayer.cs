using UnityEngine;
using System.Collections;

public class FPSPlayer : MonoBehaviour
{
    private HUD hud;
    private float maximumHitPoints = 100.0f;
    private float hitPoints = 100.0f;
    public AudioClip die;
    public AudioClip pain;

    // Use this for initialization
    private void Start()
    {
        GameObject go = GameObject.Find("GUI");
        hud = (HUD)go.GetComponent(typeof(HUD));
        hud.UpdateGUIHealth((int)hitPoints);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ApplyHealth()
    {
        hitPoints = maximumHitPoints;
    }

    private void ApplyDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            hud.UpdateGUIHealth(0);
            Die();
        }
        else
        {

            Debug.Log(hitPoints.ToString());
            AudioSource.PlayClipAtPoint(pain, transform.position);
            hud.UpdateGUIHealth((int)hitPoints);
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(die, transform.position);

        Component[] components = GetComponentsInChildren(typeof(MonoBehaviour));
        foreach (MonoBehaviour c in components)
        {
            if (c)
                c.enabled = false;
        }
        Time.timeScale = 0.0f;
        DrawHighscoreMenu();
    }

    public void DrawHighscoreMenu()
    {
        GameObject go = GameObject.Find("GUI");
        MenuState mS = (MenuState)go.GetComponent(typeof(MenuState));
        mS.PlayerIsDead = true;
        mS.DrawHighscoreMenu();
    }
}
