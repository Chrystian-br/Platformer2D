using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region VARIAVEIS
        public int startLife = 10;
        public bool destroyOnKill = false;
        public float delayToKill = 2f;

        public Animator animator;
        public string deadTrigger = "Dead";

        private float _currentLife;
        public bool _isDead = false;

        [SerializeField] private FlashColor _flashColor;
    #endregion
     
     
    #region METODOS
        public void TakeDamage(int damage)
        {
            if(_isDead) return;

            _currentLife -= damage;

            if(_currentLife <= 0)
            {
                Kill();
            }

            if(_flashColor != null)
            {
                _flashColor.damageFlash();
            }
        }

        private void Kill()
        {
            _isDead = true;

            animator.SetTrigger(deadTrigger);
            if(destroyOnKill) Destroy(gameObject, delayToKill);
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Awake()
        {
            _currentLife = startLife;
            _isDead = false;

            if(_flashColor == null)
            {
                _flashColor = GetComponent<FlashColor>();
            }
        }
    #endregion
}
