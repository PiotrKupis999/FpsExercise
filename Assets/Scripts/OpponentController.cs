using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentController : MonoBehaviour
{
    public float maxHealth = 100f; // Maximum health of the opponent
    public float currentHealth = 100f; // Current health of the opponent

    public Slider hpBar; // Reference to the HP bar UI Slider

    public RectTransform hpBarRectTransform; // Reference to the HP bar's RectTransform

    private void Start()
    {
        OpponentController opponent = new OpponentController();
        UpdateHPBar();
    }

    // Call this method in LateUpdate to update the HP bar's position
    private void LateUpdate()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        hpBarRectTransform.position = screenPos + new Vector3(0f, 100f, 0f);
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
