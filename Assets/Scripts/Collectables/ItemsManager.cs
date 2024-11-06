using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    #region VARIAVEIS
        public int coins;
        public static ItemsManager Instance;
    #endregion
     
     
    #region METODOS
        private void Reset()
        {
            coins = 0;
        }

        public void AddCoins(int amount = 1)
        {
            coins += amount;
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Awake()
        {
            if(Instance == null){
                Instance = this;
            } else {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Reset();
        }
    #endregion
}
