using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Abstracts.Texts
{
    public abstract class BaseHighScoreText : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI _highScoreText;
        protected virtual void WriteHighScoreValueIntoText() => _highScoreText.text = "HIGH SCORE: " + GetHighScoreValue();
        protected virtual string GetHighScoreValue() => ScoreManager.Instance.GetScore().ToString("0");
    }
}