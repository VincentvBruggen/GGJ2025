using EasyTextEffects;
using Unity.VisualScripting;
using UnityEngine;

public class hitshake : MonoBehaviour
{
    public TextEffect textEffect;
    public void shake()
    {
        textEffect.StartManualEffect("shake");
    }
    public void stopShake()
    {
        textEffect.StopManualEffects();
    }
}
