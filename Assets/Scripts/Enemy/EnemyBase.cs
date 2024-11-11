using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region VARIAVEIS
        public int damage = 2;

        public Animator animator;
        public string attackTrigger = "Attack";

        public HealthBase healthBase;
    #endregion
     
     
    #region METODOS
        private void AttackAnimation()
        {
            animator.SetTrigger(attackTrigger);
        }

        public void TakeDamage(int dmg)
        {
            healthBase.TakeDamage(dmg);

            
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Awake()
        {
            healthBase.destroyOnKill = true;
        }
    
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(!healthBase._isDead){
                var health = collision.gameObject.GetComponent<HealthBase>();

                if(health != null)
                {
                    health.TakeDamage(damage);
                    AttackAnimation();
                }
            }
            
        }
    #endregion
}
