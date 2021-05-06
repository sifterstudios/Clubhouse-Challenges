// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System;
using UnityEngine;
using UnityEngine.UI;

namespace SIFTER._011_GameDevClicker.Scripts
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] Text balanceText;
        [SerializeField] Text quantityText;
        [SerializeField] double startingBalance = 1; 

        double currentBalance;
        public double CurrentBalance { get { return currentBalance; } }

        double[] itemBalance;
        public double[] ItemBalance { get { return itemBalance; } }

        int[] quantities = { 1, 10, 100, 1000 };
        int currentQuantityIndex = 0;

        int currentQuantity;
        public int CurrentQuantity { get { return currentQuantity; } }

        public static Action OnQuantityChanged;

        void Awake()
        {
            currentBalance = startingBalance;
            currentQuantity = quantities[currentQuantityIndex];
            quantityText.text = string.Format("Buy\n{0}x", currentQuantity);
        }

        public void ChangeQuantity()
        {
            currentQuantityIndex++;

            if (currentQuantityIndex >= quantities.Length)
            {
                currentQuantityIndex = 0;
            }

            currentQuantity = quantities[currentQuantityIndex];
            quantityText.text = string.Format("Buy\n{0}x", currentQuantity);
            OnQuantityChanged();
        }

        public void ModifyBalance(double value)
        {
            currentBalance += value;
            balanceText.text = string.Format("${0}", currentBalance.ToString("N2"));
        }
    }
}
