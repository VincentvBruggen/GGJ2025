using UnityEngine;
using UnityEngine.UI;

public class UIstockchanger : MonoBehaviour
{
    [SerializeField] private Transform stockParent;
    public GameObject[] images;
    public GameObject Spritestart;

    private GameManager manager;
    private void Start()
    {
        images = null;
        
        manager = GameManager.Instance;

        if(manager == null)
        {
            manager = new GameManager();
        }
        changeStock(Spritestart);
    }
    public void changeStock(GameObject newStock)
    {
        images = new GameObject[manager.stockAmount];
        for (int i = 0; i < images.Length; i++)
        {
            GameObject img = Instantiate(Spritestart, stockParent);
            img.GetComponent<Image>().color = GetComponent<UIcolorchanger>().ColorStart;
            images[i] = img;
        }
    }
    public void removeStock()
    {
        Destroy(images[images.Length - 1]);
    }
}
