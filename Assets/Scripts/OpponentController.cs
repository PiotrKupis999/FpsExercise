using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpponentController : MonoBehaviour
{
    private List<IDestroyable> observers = new List<IDestroyable>();

    public float softHealth; 
    public float mediumHealth; 
    public float hardHealth; 

    private float currentHealth; 
    private float maxHealth; 

    private Slider hpBar;


    private void Start()
    {
        hpBar = GetComponentInChildren<Slider>();

        switch (tag)
        {
            case "soft":
                currentHealth = softHealth;
                maxHealth = softHealth;
                break;
            case "medium":
                currentHealth = mediumHealth;
                maxHealth = mediumHealth;
                break;
            case "hard":
                currentHealth = hardHealth;
                maxHealth = hardHealth;
                break;
        }
        UpdateHPBar();
    }

    public void UpdateHPBar()
    {
        float hpPercentage = currentHealth / maxHealth;
        hpBar.value = hpPercentage; 
    }

    public void Hit()
    {

        switch (GunsController.currentGun)
        {
            case GunsController.Guns.Pistol:
                currentHealth -= GunsController.pistolDamage;
                break;
            case GunsController.Guns.PM:
                currentHealth -= GunsController.pmDamage;
                break;
            case GunsController.Guns.M4:
                currentHealth -= GunsController.m4Damage;
                break;
        }


        UpdateHPBar();
        if (currentHealth <= 0)
        {
            foreach (var observer in observers)
            {
                observer.OnDestroy();
            }

            Destroy(this.gameObject);
            Destroy(hpBar.gameObject);
        }
    }

    public void AddObserver(IDestroyable obserwator)
    {
        observers.Add(obserwator);
    }

    public void RemoveObserver(IDestroyable obserwator)
    {
        observers.Remove(obserwator);
    }
}
