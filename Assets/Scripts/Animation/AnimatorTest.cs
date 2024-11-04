using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    #region VARIAVEIS
        public Animator animator;
        public string triggerToFly = "Fly";
        public KeyCode keyToFly = KeyCode.Z;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
        private void Update()
        {
            if(Input.GetKeyDown(keyToFly)){
                animator.SetTrigger(triggerToFly);
            }
        }

        private void OnValidate()
        {
            if(animator == null) animator = GetComponent<Animator>();
        }
    #endregion
}
