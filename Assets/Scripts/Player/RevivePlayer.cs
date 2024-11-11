using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RevivePlayer : MonoBehaviour
{
    #region VARIAVEIS
        [Header("Revive")]
        public HealthBase health;
        public Animator animator;
        public string deadTrigger = "Dead";

        [Header("Imortal")]
        public PlayerMain player;
        public List<SpriteRenderer> spriteRenderers;
        public Color imortalColor = Color.yellow;
        public float imortalDuration = 4f;

        [Header("HUD")]
        public GameObject revivePopUp;
        public TextMeshProUGUI reviveText;
        public int reviveCount = 3;
        public Button reviveButton;
    #endregion
     
     
    #region METODOS
        public void TurnOnRevivePopUp()
        {
            revivePopUp.SetActive(true);
            reviveText.text = "x" + reviveCount;

            if(reviveCount <= 0){
                reviveButton.interactable = false;
            }
        }

        public void Revive()
        {
            health._currentLife = health.startLife;
            animator.SetBool(deadTrigger, false);
            health._isDead = false;
            reviveCount--;

            health._isImortal = true;
            
            foreach(var sprite in spriteRenderers){
                sprite.color = imortalColor;
            }

            Invoke(nameof(ImortalTimer), imortalDuration);
        }

        private void ImortalTimer()
        {
            health._isImortal = false;

            foreach(var sprite in spriteRenderers){
                sprite.color = Color.white;
            }
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Awake()
        {
            spriteRenderers = new List<SpriteRenderer>();

            foreach(var child in player.transform.GetComponentsInChildren<SpriteRenderer>()){
                spriteRenderers.Add(child);
            }
        }
    #endregion
}
