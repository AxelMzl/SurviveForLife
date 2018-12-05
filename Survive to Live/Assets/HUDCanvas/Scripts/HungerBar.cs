using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HungerBar : MonoBehaviour
{

    public float startingHunger = 100f;                            // The amount of hunger the player starts the game with.
    public static float currentHunger;                                   // The current hunger the player has.
    public bool famished = false;                                   // The boolean to know if the player is famished
    public Slider hungerSlider;                                 // Reference to the UI's junger bar.



    // Use this for initialization
    void Start()
    {
        currentHunger = startingHunger;
        hungerSlider.value = currentHunger;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Timer());
        hungerSlider.value = currentHunger;

    }



    IEnumerator Timer()
    {

        yield return new WaitForSeconds(1);
        currentHunger -= 0.005f;

    }
}
