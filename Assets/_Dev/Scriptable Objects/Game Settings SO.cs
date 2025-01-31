using UnityEngine;


[CreateAssetMenu]
public class GameSettingsSO : ScriptableObject
{
    public float matchLength = 120; // In seconds
    public int stockAmount = 3;

    public float itemDropRate = 5; // Amount of seconds that has to pass to drop an item

    public float knockBackMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;
}