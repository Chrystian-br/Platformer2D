using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    #region VARIAVEIS
        public ProjectileBase prefabProjectile;
        public Transform positionToShoot;
        public float timeBetweenShoot = .2f;

        public HealthBase healthBase;
        public Transform playerSideReference;

        private Coroutine _currentCoroutine;
    #endregion
     
     
    #region METODOS
        public void Shoot()
        {
            var projectile = Instantiate(prefabProjectile);
            projectile.transform.position = positionToShoot.position;
            projectile.side = playerSideReference.transform.localScale.x;
        }

        IEnumerator StartShoot()
        {
            while(true)
            {
                Shoot();
                yield return new WaitForSeconds(timeBetweenShoot);
            }
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Update()
        {
            if(!healthBase._isDead){
                if(Input.GetKeyDown(KeyCode.Z))
                {
                    _currentCoroutine = StartCoroutine(StartShoot());
                } else if (Input.GetKeyUp(KeyCode.Z)){
                    if(_currentCoroutine != null) StopCoroutine(_currentCoroutine);
                }
            }
            
        }
    #endregion
}
