using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RysCorp.Core.Singleton;


public class GameManager : Singleton<GameManager>
{
    #region VARIAVEIS
        [Header("Player")]
        public GameObject playerPrefab;
        private GameObject _currentPlayer;

        [Header("Enemies")]
        public List<GameObject> enemies;

        [Header("References")]
        public Transform startPoint;

        
        [Header("Animation")]
        public List<GameObject> buttons;
        public float duration = .5f;
        public float delay = .1f;
        public Ease ease = Ease.OutBack;
    #endregion
     
     
    #region METODOS
        private void SpawnPlayer()
        {
            _currentPlayer = Instantiate(playerPrefab);
            _currentPlayer.transform.position = startPoint.position;
            _currentPlayer.transform.DOScale(0, duration).From().SetDelay(delay).SetEase(ease);
        }
    #endregion
     
     
    #region UNITY-METODOS
        private void Start()
        {
            SpawnPlayer();
        }
    #endregion
}
