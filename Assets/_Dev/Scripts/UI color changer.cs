using UnityEngine;
using UnityEngine.UI;

public class UIcolorchanger : MonoBehaviour
{
    public Color ColorStart;
    [SerializeField] private Image[] images;
    private void Start()
    {
        changeColor(ColorStart);
    }
    public void changeColor(Color newColor)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = newColor;
        }
    }
} 
