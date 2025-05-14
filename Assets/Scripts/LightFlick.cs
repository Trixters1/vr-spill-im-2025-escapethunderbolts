using System.Collections;
using UnityEngine;

public class LightFlick : MonoBehaviour
{
    public Light LightOB;
    public AudioSource LightSound;

    public float MinTime = 0.1f;
    public float MaxTime = 1f;
    private float Timer;

    private bool lightOn = true; // Keeps track of the current light state

    void Start()
    {
        // Set a random time interval for the light flicker
        Timer = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        // Decrement the timer by the time that has passed since the last frame
        Timer -= Time.deltaTime;

        // When the timer reaches 0, flicker the light
        if (Timer <= 0)
        {
            LightFlickering();
        }
    }

    void LightFlickering()
    {
        // Toggle light state
        lightOn = !lightOn;
        LightOB.enabled = lightOn;

        // Log the light's state (for debugging)
        Debug.Log("Light toggled: " + (lightOn ? "ON" : "OFF"));

        // Play the flicker sound
        if (LightSound != null)
        {
            LightSound.Play();
        }

        // Reset the timer with a new random value
        Timer = Random.Range(MinTime, MaxTime);
    }
}
