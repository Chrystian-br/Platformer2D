using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region VARIAVEIS
        public int damage = 2;

        public Animator animator;
        public string attackTrigger = "Attack";
    #endregion
     
     
    #region METODOS
    
    #endregion
     
     
    #region UNITY-METODOS
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var health = collision.gameObject.GetComponent<HealthBase>();

            if(health != null)
            {
                health.TakeDamage(damage);
                AttackAnimation();
            }
        }

        private void AttackAnimation()
        {
            animator.SetTrigger(attackTrigger);
        }
    #endregion
}
