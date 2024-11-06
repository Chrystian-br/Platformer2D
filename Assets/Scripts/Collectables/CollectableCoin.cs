using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : CollectableBase
{
    #region VARIAVEIS
        
    #endregion


    #region METODOS
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemsManager.Instance.AddCoins();
    }
    #endregion


    #region UNITY-METODOS

    #endregion
}
