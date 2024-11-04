using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMain : MonoBehaviour
{
    #region VARIAVEIS
        [Header("Movement Setup")]
        public Rigidbody2D playerRigidBody;
        public float speed = 5;
        public float speedRun = 2;

        public float jump = 2;
        public Vector2 friction = new Vector2(.1f,0);

        [Header("Animation setup")]
        public float jumpScaleY = 1.3f;
        public float jumpScaleX = .7f;

        public float fallScaleY = .7f;
        public float fallScaleX = 1.3f;

        public float animationDur = .3f;
        public Ease ease = Ease.OutBack;
        

        private bool _checkJump = false;
        private float _currentSpeed;
    #endregion
     
     
    #region METODOS
        private void PlayerMovement()
        {
            _currentSpeed = Input.GetKey(KeyCode.LeftControl) ? speed * speedRun : speed;

            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
                playerRigidBody.velocity = new Vector2(-_currentSpeed, playerRigidBody.velocity.y);
            }
            else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
                playerRigidBody.velocity = new Vector2(_currentSpeed, playerRigidBody.velocity.y);
            }

            if(playerRigidBody.velocity.x > 0){
                playerRigidBody.velocity -= friction;
            }
            else if(playerRigidBody.velocity.x < 0){
                playerRigidBody.velocity += friction;
            }
        }

        private void PlayerJump()
        {
            var RBTransform = playerRigidBody.transform;

            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)){
                if(_checkJump){
                    playerRigidBody.velocity = Vector2.up * jump;
                    RBTransform.localScale = Vector2.one;

                    DOTween.Kill(RBTransform);

                    RBTransform.DOScaleY(jumpScaleY, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(ease);
                    RBTransform.DOScaleX(jumpScaleX, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(ease);

                    _checkJump = false;
                }
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            
            _checkJump = true;

        }
    #endregion
     
     
    #region UNITY-METODOS
        void Update()
        {
            PlayerJump();
            PlayerMovement();
        }
    #endregion
}
