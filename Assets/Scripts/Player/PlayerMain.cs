using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    #region VARIAVEIS
        public Rigidbody2D playerRigidBody;
        public float speed = 5;

        public float jump = 2;
        public Vector2 friction = new Vector2(.1f,0);

        private bool _checkJump = false;
        private float _currentSpeed;
    #endregion
     
     
    #region METODOS
        private void PlayerMovement()
        {
            _currentSpeed = Input.GetKey(KeyCode.LeftControl) ? speed * 2 : speed;

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
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)){
                if(_checkJump){
                    playerRigidBody.velocity = Vector2.up * jump;
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
