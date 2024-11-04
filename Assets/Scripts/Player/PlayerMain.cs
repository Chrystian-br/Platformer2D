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
        public float animationDur = .3f;
        public Ease ease = Ease.OutBack;
        
        [Header("Animation player")]
        public Animator animator;
        public string runBool = "Run";
        public string jumpTrigger = "Jump";
        public float swipeDuration = .1f;
        
        private bool _checkDirection = false;
        private Vector2 leftDirection = new Vector2(-1,1);
        private Vector2 rightDirection = new Vector2(1,1);

        public HealthBase health;

        private bool _checkJump = false;
        private float _currentSpeed;
    #endregion
     
     
    #region METODOS
        private void PlayerMovement()
        {
            if(!health._isDead){
                _currentSpeed = Input.GetKey(KeyCode.LeftControl) ? speed * speedRun : speed;

                if(Input.GetKey(KeyCode.LeftControl)){
                    _currentSpeed = speed * speedRun;
                    animator.speed = 2;
                } else {
                    _currentSpeed = speed;
                    animator.speed = 1;
                }

                if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
                    playerRigidBody.velocity = new Vector2(-_currentSpeed, playerRigidBody.velocity.y);

                    if(!_checkDirection){
                        playerRigidBody.transform.DOScaleX(-1, swipeDuration);
                    }

                    _checkDirection = true;

                    animator.SetBool(runBool, true);
                }
                else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
                    playerRigidBody.velocity = new Vector2(_currentSpeed, playerRigidBody.velocity.y);

                    if(_checkDirection){
                        playerRigidBody.transform.DOScaleX(1, swipeDuration);
                    }

                    _checkDirection = false;

                    animator.SetBool(runBool, true);
                }
                else{
                    animator.SetBool(runBool, false);
                }


                if(playerRigidBody.velocity.x > 0){
                    playerRigidBody.velocity -= friction;
                }
                else if(playerRigidBody.velocity.x < 0){
                    playerRigidBody.velocity += friction;
                }
            }
            
        }

        private void PlayerJump()
        {
            if(!health._isDead){
                var RBTransform = playerRigidBody.transform;

                if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)){
                    if(_checkJump){
                        playerRigidBody.velocity = Vector2.up * jump;

                        RBTransform.localScale = Vector2.one;

                        DOTween.Kill(RBTransform);

                        if(!_checkDirection){
                            RBTransform.localScale = rightDirection;
                            RBTransform.DOScaleY(jumpScaleY, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(ease);
                            RBTransform.DOScaleX(jumpScaleX, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(ease);
                        } else {
                            RBTransform.localScale = leftDirection;
                            RBTransform.DOScaleY(jumpScaleY, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(ease);
                            RBTransform.DOScaleX(-jumpScaleX, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(ease);
                        }

                        _checkJump = false;

                        animator.SetTrigger(jumpTrigger);
                    }
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
