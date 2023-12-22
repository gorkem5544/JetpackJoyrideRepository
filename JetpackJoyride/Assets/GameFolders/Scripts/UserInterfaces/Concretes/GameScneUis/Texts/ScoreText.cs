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

        IncreaseScore _increaseScore;
        private void Awake()
        {
            _increaseScore = new IncreaseScore(_scoreText);
        }

        private void Update()
        {
            _increaseScore.IncreaseCoreUpdateTick();
        }

    }


}
public class IncreaseScore
{
    private float _currentScore, _multipleFactor = 1;
    public float Score => _currentScore;
    TextMeshProUGUI _scoreText;
    public IncreaseScore(TextMeshProUGUI scoreText)
    {
        _scoreText = scoreText;
    }
    public void IncreaseCoreUpdateTick()
    {
        IncreaseMultipleFactor();
        if (GameManager.Instance.GameManagerState == GameManagerState.GameState)
        {
            _currentScore += Time.deltaTime * _multipleFactor;
            _scoreText.text = _currentScore.ToString("0");
            ScoreManager.Instance.SaveScore(_currentScore);
        }
    }
    private void IncreaseMultipleFactor(float value = 0.002f) => _multipleFactor += value;

}