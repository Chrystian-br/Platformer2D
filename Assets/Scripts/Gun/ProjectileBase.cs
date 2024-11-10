using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    #region VARIAVEIS
        public Vector3 direction;
        public float timeToDestroy = 1.5f;

        public float side = 1;
        public int damageAmount = 1;
    #endregion
     
     
    #region METODOS

    #endregion
     
     
    #region UNITY-METODOS
        private void Update()
        {
            transform.Translate(direction * Time.deltaTime * side);
        }
        
        private void Awake()
        {
            Destroy(gameObject,timeToDestroy);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var enemy = collision.transform.GetComponent<EnemyBase>();

            if(enemy != null){
               enemy.TakeDamage(damageAmount);
               Destroy(gameObject);
            }
        }
    #endregion
}
