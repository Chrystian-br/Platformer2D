using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMain : MonoBehaviour
{
    #region VARIAVEIS
        [Header("Setup")]
        public SOPlayer SOPlayerSetup;
        public Rigidbody2D playerRigidBody;
        // public Animator animator;
        public HealthBase health;
        
        private Vector2 leftDirection = new Vector2(-1,1);
        private Vector2 rightDirection = new Vector2(1,1);
        
        private bool _checkJump = false;
        private bool _checkDirection = false;
        private float _currentSpeed;
        private Animator _currentPlayer;

    #endregion
     
     
    #region METODOS
        private void PlayerMovement()
        {
            if(!health._isDead){
                _currentSpeed = Input.GetKey(KeyCode.LeftControl) ? SOPlayerSetup.speed * SOPlayerSetup.speedRun : SOPlayerSetup.speed;

                if(Input.GetKey(KeyCode.LeftControl)){
                    _currentSpeed = SOPlayerSetup.speed * SOPlayerSetup.speedRun;
                    _currentPlayer.speed = 2;
                } else {
                    _currentSpeed = SOPlayerSetup.speed;
                    _currentPlayer.speed = 1;
                }

                if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
                    playerRigidBody.velocity = new Vector2(-_currentSpeed, playerRigidBody.velocity.y);

                    if(!_checkDirection){
                        playerRigidBody.transform.DOScaleX(-1, SOPlayerSetup.swipeDuration);
                    }

                    _checkDirection = true;

                    _currentPlayer.SetBool(SOPlayerSetup.runBool, true);
                }
                else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
                    playerRigidBody.velocity = new Vector2(_currentSpeed, playerRigidBody.velocity.y);

                    if(_checkDirection){
                        playerRigidBody.transform.DOScaleX(1, SOPlayerSetup.swipeDuration);
                    }

                    _checkDirection = false;

                    _currentPlayer.SetBool(SOPlayerSetup.runBool, true);
                }
                else{
                    _currentPlayer.SetBool(SOPlayerSetup.runBool, false);
                }


                if(playerRigidBody.velocity.x > 0){
                    playerRigidBody.velocity -= SOPlayerSetup.friction;
                }
                else if(playerRigidBody.velocity.x < 0){
                    playerRigidBody.velocity += SOPlayerSetup.friction;
                }
            }
        }

        private void PlayerJump()
        {
            if(!health._isDead){
                var RBTransform = playerRigidBody.transform;

                if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)){
                    if(_checkJump){
                        playerRigidBody.velocity = Vector2.up * SOPlayerSetup.jump;

                        RBTransform.localScale = Vector2.one;

                        DOTween.Kill(RBTransform);

                        if(!_checkDirection){
                            RBTransform.localScale = rightDirection;
                            RBTransform.DOScaleY(SOPlayerSetup.jumpScaleY, SOPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
                            RBTransform.DOScaleX(SOPlayerSetup.jumpScaleX, SOPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
                        } else {
                            RBTransform.localScale = leftDirection;
                            RBTransform.DOScaleY(SOPlayerSetup.jumpScaleY, SOPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
                            RBTransform.DOScaleX(-SOPlayerSetup.jumpScaleX, SOPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(SOPlayerSetup.ease);
                        }

                        _checkJump = false;

                        _currentPlayer.SetTrigger(SOPlayerSetup.jumpTrigger);
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

        void Awake()
        {
            _currentPlayer = Instantiate(SOPlayerSetup.player, transform);
        }
    #endregion
}
