using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationGameObject : MonoBehaviour
{
    #region VARIAVEIS
        public float speed = 5f;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
        private void Update()
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    #endregion
}
