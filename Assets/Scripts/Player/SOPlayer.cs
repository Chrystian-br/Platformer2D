using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    #region VARIAVEIS
        [Header("Movement Setup")]
        public float speed = 5;
        public float speedRun = 2;

        public float jump = 2;
        public Vector2 friction = new Vector2(.1f,0);

        [Header("Animation setup")]
        public float jumpScaleY;
        public float jumpScaleX;
        public float animationDur;
        public Ease ease = Ease.OutBack;
        
        [Header("Animation player")]
        public Animator player;
        public string runBool = "Run";
        public string jumpTrigger = "Jump";
        public float swipeDuration = .1f;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
     
    #endregion
}
