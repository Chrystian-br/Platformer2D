using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    #region VARIAVEIS
        public string compareTag = "Player";
        
        public float animationCollectDelay = 0.3f;

        public TextMeshProUGUI coinText;
    #endregion
     
     
    #region METODOS
        protected virtual void Collect()
        {
            OnCollect();
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect()
        {
            coinText.text = ItemsManager.Instance.coins + " x";
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.transform.CompareTag(compareTag)){
                gameObject.transform.GetComponent<CircleCollider2D>().isTrigger = false;
                gameObject.transform.DOScale(0,animationCollectDelay);
                gameObject.transform.DOLocalMoveX(collision.transform.position.x, animationCollectDelay);

                Invoke(nameof(Collect),animationCollectDelay);
            }
        }
    #endregion
}
