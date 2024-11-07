using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RysCorp.Core.Singleton;

public class ItemsManager : Singleton<ItemsManager>
{
    #region VARIAVEIS
        public int coins;
        
        public TextMeshProUGUI coinText;
    #endregion
     
     
    #region METODOS
        private void Reset()
        {
            coins = 0;
        }

        public void AddCoins(int amount = 1)
        {
            coins += amount;
            coinText.text = coins + " x";
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Start()
        {
            Reset();
        }
    #endregion
}
