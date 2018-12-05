﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HealthBar: MonoBehaviour
{

    public int startingHealth = 100;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Canvas GameHUD;                                      // Reference to the Game HUD.
    public Canvas DeathHUD;                                     // Reference to the Death HUD.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public int timerTestDamage = 0;

    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.


    void Awake()
    { 
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;


    }

    void Update()
    {
        if (timerTestDamage > 10)
        {
            TakeDamage(10);
            timerTestDamage = 0;
        }
        else
        {
            //timerTestDamage++;
        }
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;


        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }


    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Hide Health and tell the player that he is dead   
        GameHUD.gameObject.SetActive(false);

        // Show the Death Text
        DeathHUD.gameObject.SetActive(true);
    }
}