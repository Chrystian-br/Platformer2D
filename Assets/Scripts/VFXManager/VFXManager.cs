using System.Collections;
using System.Collections.Generic;
using RysCorp.Core.Singleton;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
   #region VARIAVEIS
        public enum VFXType
        {
            JUMP,
            VFX_2
        }

        public List<VFXManagerSetup> vfxSetup;
   #endregion
    
    
   #region METODOS
        public void PlayVFXByType(VFXType vfxType, Vector3 position)
        {
            foreach(var i in vfxSetup)
            {
                if(i.vfxType == vfxType){
                    var item = Instantiate(i.prefab);
                    item.transform.position = position;
                    Destroy(item.gameObject, 3f);
                    break;
                }
            }
        }
   #endregion
    
    
   #region UNITY-METODOS
    
   #endregion
}

[System.Serializable]
public class VFXManagerSetup
{
    #region VARIAVEIS
        public VFXManager.VFXType vfxType;
        public GameObject prefab;
    #endregion
     
     
    #region METODOS
     
    #endregion
     
     
    #region UNITY-METODOS
     
    #endregion
}