using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentController : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the opponent
    public float currentHealth = 100f; // Current health of the opponent

    //public Slider hpBarPrefab;
    public Slider hpBar; // Reference to the HP bar UI Slider
    //private RectTransform hpBarRectTransform; // Reference to the HP bar's RectTransform

    public float maxRenderDistance = 20f; // Maximum distance at which the HP bar is rendered


    private void Start()
    {
        //hpBar = Instantiate(hpBarPrefab);
        //hpBarRectTransform = hpBar.GetComponent<RectTransform>();
        UpdateHPBar();
    }

    // Call this method in LateUpdate to update the HP bar's position
    private void LateUpdate()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 hpBarPos = screenPos + new Vector3(0f, 100f, 0f);

        // Calculate distance between the opponent and the player
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        if (distance < maxRenderDistance)
        {
            // Opponent is within the rendering distance, show the HP bar
            hpBar.transform.position = hpBarPos;
        }
        else
        {
            // Opponent is beyond the rendering distance, disable HP bar rendering
            hpBar.transform.position = new Vector3(-1000f, -1000f, 0f);
        }
    }

    // Call this method to update the HP bar
    public void UpdateHPBar()
    {
        float hpPercentage = currentHealth / maxHealth;
        hpBar.value = hpPercentage; // Set the value of the Slider to the HP percentage
    }

    public void Hit()
    {
        currentHealth -= maxHealth / 4;
        UpdateHPBar();
        if (currentHealth <= 0)
        {

            Destroy(this.gameObject);
            Destroy(hpBar.gameObject);
        }
    }

}
