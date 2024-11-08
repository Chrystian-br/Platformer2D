using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    #region VARIAVEIS
        public List<SpriteRenderer> spriteRenderers;
        public float duration = .1f;

        [Header("Colors")]
        public Color damageColor = Color.red;

        private Tween _currentTween;
    #endregion
     
     
    #region METODOS
        public void damageFlash()
        {
            if(_currentTween != null)
            {
                _currentTween.Kill();
                spriteRenderers.ForEach(i => i.color = Color.white);
            }

            foreach(var s in spriteRenderers)
            {
                _currentTween = s.DOColor(damageColor, duration).SetLoops(2, LoopType.Yoyo);
            }
        }
    #endregion
     
     
    #region UNITY-METODOS
        public void OnValidate()
        {
            spriteRenderers = new List<SpriteRenderer>();
            foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderers.Add(child);
            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.U))
            {
                damageFlash();
            }
        }
    #endregion
}
