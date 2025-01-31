using UnityEngine;
using UnityEngine.UI;

public class UIcolorchanger : MonoBehaviour
{
    private Color Color;
    [SerializeField] private Image[] images;
    public void changeColor(Color newColor)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = newColor;
        }
    }
} 
