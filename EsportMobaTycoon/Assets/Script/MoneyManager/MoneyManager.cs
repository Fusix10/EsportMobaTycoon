using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{

    private int m_money_amount;

    [Header("Money Settings")]
    [SerializeField]
    private int money_start_amount;

    [Header("Ui Settings")]
    [SerializeField]
    private TMP_Text money_text;

    public int MoneyAmount
    {
        get { return m_money_amount; }
        private set { m_money_amount = value; }
    }

    void Start()
    {
        MoneyAmount = money_start_amount;
    }

    void Update()
    {
        money_text.text = MoneyAmount.ToString();
    }

    public void AddMoney(int amount)
    {
        MoneyAmount += amount;
    }

    private void SubtractMoney(int amount)
    {
        MoneyAmount -= amount;
    }

    // Substract by checking if player have enough money. If not return.
    public void PurchaseWithMoney(int amount)
    {
        if (m_money_amount < amount) return;

        SubtractMoney(amount);
    }

    // Substract amount. If below zero, set to zero.
    public void RemoveMoney(int amount)
    {
        if ((m_money_amount - amount) < 0)
        {
            MoneyAmount = 0;
            return;
        }

        SubtractMoney(amount);
    }

    public void MultiplyMoney(float amount)
    {
        MoneyAmount = Mathf.Max(0, Mathf.RoundToInt(m_money_amount * amount));
    }

    public void DivideMoney(float amount)
    {
        if (amount == 0) return;

        MoneyAmount = Mathf.Max(0, Mathf.RoundToInt(m_money_amount / amount));
    }
    public void SetMoney(int amount)
    {
        MoneyAmount = amount;
    }


}
