using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class StaminaBar : MonoBehaviour
{

    public int startingStamina = 100;                            // The amount of stamina the player starts the game with.
    public int currentStamina;                                   // The current stamina the player has.
    public int checkStamina;                                   // The current stamina the player has to check if the value is changed.
    public bool tired = false;                                   // The boolean to know if the player is tired
    public Slider currentHungerSlider;                                 // Reference to the UI's hunger Bar
    public Slider staminaSlider;                                 // Reference to the UI's stamina bar.


    // Use this for initialization
    void Start()
    {
        currentStamina = startingStamina;
        checkStamina = startingStamina;
        staminaSlider.value = currentStamina;
        

    }

    // Update is called once per frame
    void Update()
    {
        checkStamina = currentStamina;
        if (currentStamina > 1)
        {
            Sprint();

            // check if the the value of stamina is changed
            if (checkStamina == currentStamina)
            {
                // check if the current stamina = 100
                if (currentStamina == 100)
                {
                    // nothing
                }
                else
                {
                    // if the current stamina is not equal to 100 then recover stamina
                    RecoverStamina();
                }
            }
        }
        else
        {
            StartCoroutine(Tired());
        }
    }

    public void RecoverStamina()
    {
        // Increment his current stamina..
        currentStamina += 1;
        //..  and det the stamina bar's value to the current stamina.
        staminaSlider.value = currentStamina;
    }



    public void Sprint()
    {
        //if the player use the key left shift to sprint, only if his stamina > 0
        if (Input.GetKey("left shift"))
        {
            // Decrement his current stamina..
            currentStamina -= 1;
            //..  and det the stamina bar's value to the current stamina.
            staminaSlider.value = currentStamina;

            // Don't forget to lose hunger there
            //HungerBar.currentHunger; 


        }
    }

    IEnumerator Tired()
    {
        tired = true;
        yield return new WaitForSeconds(1);
        tired = false;
        RecoverStamina();

    }
}