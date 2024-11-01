using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuBtnManager : MonoBehaviour
{
    #region VARIAVEIS
        [Header("Animation")]
        public List<GameObject> buttons;
        public float duration = .5f;
        public float delay = .1f;
        public Ease ease = Ease.OutBack;
    #endregion
     
     
    #region METODOS
        private void HideAllButtons()
        {
            foreach(var b in buttons)
            {
                b.transform.localScale = Vector3.zero;
            }
        }

        private void ShowButtons()
        {
            for(var i = 0; i < buttons.Count; i++)
            {
                var b = buttons[i];
                b.SetActive(true);
                b.transform.DOScale(1,duration).SetDelay(i*delay).SetEase(ease);
            }
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void OnEnable()
        {
            HideAllButtons();
            ShowButtons();
        }
    #endregion
}
