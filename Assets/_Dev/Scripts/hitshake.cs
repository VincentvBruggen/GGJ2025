using EasyTextEffects;
using UnityEngine;

public class hitshake : MonoBehaviour
{
    public TextEffect textEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textEffect.StartManualEffect("shake");
            textEffect.StartManualEffect("shit");

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            textEffect.StopManualEffects();
        }
    }
}
