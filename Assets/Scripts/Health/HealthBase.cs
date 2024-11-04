using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region VARIAVEIS
        public int startLife = 10;
        public bool destroyOnKill = false;
        public float delayToKill = 2f;

        private float _currentLife;
        private bool _isDead = false;
    #endregion
     
     
    #region METODOS
        public void TakeDamage(int damage)
        {
            _currentLife -= damage;

            if(_currentLife <= 0)
            {
                Kill();
            }
        }

        private void Kill()
        {
            _isDead = true;

            if(destroyOnKill) Destroy(gameObject, delayToKill);
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Awake()
        {
            _currentLife = startLife;
            _isDead = false;
        }
    #endregion
}
