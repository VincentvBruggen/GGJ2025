using UnityEngine;
using UnityEngine.UI;

public class UIstockchanger : MonoBehaviour
{
    [SerializeField] private Image[] images;
    public Sprite Spritestart;

    private GameManager manager;
    private void Start()
    {
        changeStock(Spritestart);
        
        manager = GameManager.Instance;

        if(manager == null)
        {
            manager = new GameManager();
        }
    }
    public void changeStock(Sprite newStock)
    {
        images = new Image[manager.stockAmount];
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = newStock;
        }
    }
}
