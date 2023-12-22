using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

public class HighScoreInformationText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;
    private void Update()
    {
        _textMeshProUGUI.text = ScoreManager.Instance.GetScore().ToString("0");
    }
}
