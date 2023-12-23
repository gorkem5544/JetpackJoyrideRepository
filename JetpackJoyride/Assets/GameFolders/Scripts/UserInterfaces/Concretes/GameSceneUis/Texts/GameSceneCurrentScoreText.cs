using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameSceneUis.Texts
{
    public class GameSceneCurrentScoreText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private IncreaseScore _increaseScore;

        private void Awake() => _increaseScore = new IncreaseScore(_scoreText);
        private void Update() => _increaseScore.IncreaseScoreUpdateTick();

    }
}
public class IncreaseScore
{
    private float _currentScore, _multipleFactor = 1;
    private TextMeshProUGUI _scoreText;

    public IncreaseScore(TextMeshProUGUI scoreText) => _scoreText = scoreText;

    public void IncreaseScoreUpdateTick()
    {
        if (GameManager.Instance.GameManagerState == GameManagerState.GameState)
        {
            _currentScore += Time.deltaTime * IncreaseMultipleFactor();
            _scoreText.text = _currentScore.ToString("0");
            ScoreManager.Instance.SaveScore(_currentScore);
        }
    }
    private float IncreaseMultipleFactor(float value = 0.002f) => _multipleFactor += value;



}