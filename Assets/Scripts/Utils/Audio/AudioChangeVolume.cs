using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioChangeVolume : MonoBehaviour
{
    #region VARIAVEIS
        public AudioMixer group;
        public string floatParam = "VolumeAmbience";
    #endregion
     
     
    #region METODOS
        public void ChangeValue(float f)
        {
            group.SetFloat(floatParam, f);
        }
    #endregion
}
