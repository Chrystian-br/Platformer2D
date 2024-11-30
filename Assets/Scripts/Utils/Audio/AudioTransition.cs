using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition : MonoBehaviour
{
    #region VARIAVEIS
        public AudioMixerSnapshot snapshot;
        public float transitionTime = .1f;
    #endregion
     
     
    #region METODOS
        public void MakeTransition()
        {
            snapshot.TransitionTo(transitionTime);
        }
    #endregion
     
     
    #region UNITY-METODOS
     
    #endregion
}
