using System.Collections;
using EasyTextEffects;
using Unity.VisualScripting;
using UnityEngine;

public class hitshake : MonoBehaviour
{
    public TextEffect textEffect;
    public void shake()
    {
        textEffect.StartManualEffect("shake");
        StartCoroutine(stopShake());
    }
    public IEnumerator stopShake()
    {
        yield return new WaitForSeconds(0.2f);
        textEffect.StopManualEffects();
    }
}
