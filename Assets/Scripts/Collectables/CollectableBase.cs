using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    #region VARIAVEIS
        public string compareTag = "Player";
        
        public float animationCollectDelay = 0.5f;

        public ParticleSystem pSystem;
        public GameObject floor;
    #endregion
     
     
    #region METODOS
        protected virtual void Collect()
        {
            OnCollect();
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            if(pSystem != null) pSystem.Play();
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.transform.CompareTag(compareTag)){
                gameObject.transform.GetComponent<CircleCollider2D>().enabled = false;
                gameObject.transform.DOScale(0,animationCollectDelay);
                gameObject.transform.DOLocalMoveX(collision.transform.position.x, animationCollectDelay);

                Invoke(nameof(Collect),animationCollectDelay - 0.2f);
            }
        }

        private void Awake()
        {
            if(pSystem != null){
                pSystem.transform.SetParent(null);
                pSystem.collision.AddPlane(floor.transform);
            }
        }
    #endregion
}
