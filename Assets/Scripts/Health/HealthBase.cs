using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    #region VARIAVEIS
        public int startLife = 10;
        public bool destroyOnKill = false;
        public float delayToKill = 4f;

        public Animator animator;
        public string deadTrigger = "Dead";

        [NonSerialized] public float _currentLife;
        public bool _isDead = false;

        private FlashColor _flashColor;

        public RevivePlayer revive;
        public bool _isImortal = false;

        [Header("Sounds")]
        public AudioSource enemyDieAudio;
    #endregion
     
     
    #region METODOS
        public void TakeDamage(int damage)
        {
            if(!_isImortal){
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
            
        }

        private void Kill()
        {
            _isDead = true;

            animator.SetTrigger(deadTrigger);
            gameObject.GetComponent<Collider2D>().enabled = false;

            if(destroyOnKill) Destroy(gameObject, delayToKill);

            if(gameObject.GetComponent<PlayerMain>()){
                revive.TurnOnRevivePopUp();
            }

            if(gameObject.GetComponent<EnemyBase>()){
                ItemsManager.Instance.AddKills(1);
                enemyDieAudio.Play();
            }
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

            if(transform.GetComponent<PlayerMain>()){
                animator = transform.GetComponentInChildren<Animator>();
                _flashColor = transform.GetComponentInChildren<FlashColor>();
            }
        }
    #endregion
}
