using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    #region VARIAVEIS
        public KeyCode keyCode = KeyCode.P;
        public AudioSource audioSource;
    #endregion
     
     
    #region METODOS
        public void Play()
        {
            audioSource.Play();
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Update()
        {
            if(Input.GetKeyDown(keyCode)){
                Play();
            }
        }
    #endregion
}
