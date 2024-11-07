using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    #region VARIAVEIS
        public int damage = 2;
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
            }
        }
    #endregion
}
