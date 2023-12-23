using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using TMPro;
using UnityEngine;

public class GameOverTimerText : MonoBehaviour
{
    private float _maxTimer = 7;
    TextMeshProUGUI _textMeshProUGUI;
    public System.Action GameOverAction { get; set; }
    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        _maxTimer -= Time.deltaTime;
        _textMeshProUGUI.text = _maxTimer.ToString();
        if (_maxTimer <= 0)
        {
            LevelManager.Instance.LoadMenuScene("Menu");
        }
    }
    private void OnDisable()
    {
        _maxTimer = 7;
    }
}
