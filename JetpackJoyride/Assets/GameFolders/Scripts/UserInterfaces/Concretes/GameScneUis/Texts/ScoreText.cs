using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameSceneUis.Texts
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _scoreText;

        float _currentScore;
        float _multipleValue;
        private void Start()
        {
            _currentScore = 0;
            _multipleValue = 1;
        }
        private void Update()
        {
            ChangeMultipleValue();
            if (GameManager.Instance.GameManagerState == GameManagerState.GameState)
            {
                _currentScore += Time.deltaTime * _multipleValue;
                _scoreText.text = _currentScore.ToString("0");
            }
        }

        public void ChangeMultipleValue(float value = 0.002f)
        {
            _multipleValue += value;
        }
    }

}