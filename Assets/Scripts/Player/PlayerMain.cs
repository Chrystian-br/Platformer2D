using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    #region VARIAVEIS
        public Rigidbody2D playerRigidBody;
        public float speed = 5;
        public float jump;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
        void Update()
        {
            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
                playerRigidBody.velocity = new Vector2(-speed, playerRigidBody.velocity.y);
            }
            else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
                playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
            }

            if(Input.GetKey(KeyCode.UpArrow)){
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jump);
            }
        }
    #endregion
}
