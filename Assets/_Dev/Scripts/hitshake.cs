using System.Collections;
using EasyTextEffects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class hitshake : MonoBehaviour
{
    public TextEffect textEffect;
    public AudioSource audioSource;
    public void shake()
    {
        textEffect.StartManualEffect("shake");
        if (audioSource != null)
        {
            audioSource.Play();
        } else
        {
            Debug.LogWarning("GEEN AUDO SOURCE PLS FIX RN");
        }
        StartCoroutine(stopShake());
    }
    public IEnumerator stopShake()
    {
        yield return new WaitForSeconds(0.2f);
        textEffect.StopManualEffects();
    }
}
