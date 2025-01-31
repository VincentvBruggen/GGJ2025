using TMPro;
using UnityEngine;

public class GameManagerFunctions : MonoBehaviour
{
    // The whole reason this THING exists is for if you wanna use functions from the gamemanager on a button

    private GameManager m_gameManager;

    [SerializeField] private TextMeshProUGUI m_matchLengthText;
    [SerializeField] private TextMeshProUGUI m_stockAmountText;
    [SerializeField] private TextMeshProUGUI m_itemDropRateText;
    [SerializeField] private TextMeshProUGUI m_knockBackMultiplierText;
    [SerializeField] private TextMeshProUGUI m_damageMultiplierText;

    private void Awake()
    {
        m_gameManager = FindFirstObjectByType<GameManager>();

        // Change Texts
        m_matchLengthText.SetText("Match Length: " + m_gameManager.matchLength.ToString());
        m_stockAmountText.SetText("Stock Amount: " + m_gameManager.stockAmount.ToString());
        m_itemDropRateText.SetText("Item Drop Rate: " + m_gameManager.itemDropRate.ToString());
        m_knockBackMultiplierText.SetText("Knockback: x" + m_gameManager.knockBackMultiplier.ToString());
        m_damageMultiplierText.SetText("Damage: x" + m_gameManager.damageMultiplier.ToString());
    }

    public void ResetToDefaultMatchSettings()
    {
        // Reset values
        m_gameManager.matchLength = m_gameManager.m_defaultGameSettings.matchLength;
        m_gameManager.stockAmount = m_gameManager.m_defaultGameSettings.stockAmount;
        m_gameManager.itemDropRate = m_gameManager.m_defaultGameSettings.itemDropRate;
        m_gameManager.knockBackMultiplier = m_gameManager.m_defaultGameSettings.knockBackMultiplier;
        m_gameManager.damageMultiplier = m_gameManager.m_defaultGameSettings.damageMultiplier;

        // Change Texts
        m_matchLengthText.SetText("Match Length: " + m_gameManager.matchLength.ToString());
        m_stockAmountText.SetText("Stock Amount: " + m_gameManager.stockAmount.ToString());
        m_itemDropRateText.SetText("Item Drop Rate: " + m_gameManager.itemDropRate.ToString());
        m_knockBackMultiplierText.SetText("Knockback: x" + m_gameManager.knockBackMultiplier.ToString());
        m_damageMultiplierText.SetText("Damage: x" + m_gameManager.damageMultiplier.ToString());
    }

    public void ChangeScene(string _scene)
    {
        if (m_gameManager != null)
        {
            m_gameManager.ChangeScene(_scene);
        }
    }

    public void ChangeMatchLength(float _amount)
    {
        if (m_gameManager != null)
        {
            m_gameManager.matchLength += _amount;

            if (m_gameManager.matchLength < 15)
            {
                m_gameManager.matchLength = 15;
            }

            m_matchLengthText.SetText("Match Length: " + m_gameManager.matchLength.ToString() + "S");
        }
    }

    public void ChangeStockAmount(int _amount)
    {
        if (m_gameManager != null)
        {
            m_gameManager.stockAmount += _amount;

            if (m_gameManager.stockAmount < 1)
            {
                m_gameManager.stockAmount = 1;
            }

            m_stockAmountText.SetText("Stock Amount: " + m_gameManager.stockAmount.ToString());
        }
    }

    public void ChangeItemDropRate(float _amount)
    {
        if (m_gameManager != null)
        {
            m_gameManager.itemDropRate += _amount;

            if (m_gameManager.itemDropRate < 0)
            {
                m_gameManager.itemDropRate = 0;
            }

            m_itemDropRateText.SetText("Item Drop Rate: " + m_gameManager.itemDropRate.ToString());
        }   
    }

    public void ChangeKnockBackMultiplier(float _amount)
    {
        if (m_gameManager != null)
        {
            m_gameManager.knockBackMultiplier += _amount;
            
            if (m_gameManager.knockBackMultiplier < 0)
            {
                m_gameManager.knockBackMultiplier = 0;
            }

            m_knockBackMultiplierText.SetText("Knockback: x" + m_gameManager.knockBackMultiplier.ToString());
        }
    }

    public void ChangeDamageMultiplier(float _amount)
    {
        if (m_gameManager != null)
        {
            m_gameManager.damageMultiplier += _amount;
        
            if (m_gameManager.damageMultiplier < 0)
            {
                m_gameManager.damageMultiplier = 0;
            }

            m_damageMultiplierText.SetText("Damage: x" + m_gameManager.damageMultiplier.ToString());
        }
    }
}