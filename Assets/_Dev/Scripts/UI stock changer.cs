using UnityEngine;
using UnityEngine.UI;

public class UIstockchanger : MonoBehaviour
{
    [SerializeField] private Image[] images;
    public Sprite Spritestart;
    private void Start()
    {
        changeStock(Spritestart);
    }
    public void changeStock(Sprite newStock)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = newStock;
        }
    }
}
