using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Objects;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Panels;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameScneUis.Texts;
using Newtonsoft.Json;
using UnityEngine;

public class Gameİnitializer : MonoBehaviour
{
    [SerializeField] private PlayerController _playerInstantiatePrefab;
    public PlayerController _currentInstantiatePlayer { get; set; }
    PlayerDetailSO _selectionPlayerDetailSO;
    [SerializeField] private PlayerDetailSO _defaultPlayerDetailSO;

    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private GameOverObject _gameOverObject;
    [SerializeField] private GameSceneGoldInfoText _gameSceneGoldInfoText;
    private void Awake()
    {
        LoadPlayerDetails();

        _gameOverObject.Initialize(_currentInstantiatePlayer);
        _gameOverPanel.Initialize(_currentInstantiatePlayer);
        _gameSceneGoldInfoText.Initialize(_currentInstantiatePlayer);
    }

    private void LoadPlayerDetails()
    {
        string playerDetailJson = PlayerPrefs.GetString("SelectedPlayer");
        if (!string.IsNullOrEmpty(playerDetailJson))
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new ColorConverter());

            try
            {
                _selectionPlayerDetailSO = JsonConvert.DeserializeObject<PlayerDetailSO>(playerDetailJson, settings);
            }
            catch (JsonSerializationException ex)
            {
                Debug.LogError($"Error deserializing player details: {ex.Message}");
                _selectionPlayerDetailSO = _defaultPlayerDetailSO;
            }
        }
        else
        {
            _selectionPlayerDetailSO = _defaultPlayerDetailSO;
        }

        InstantiatePlayer();
    }


    public void SelectionPlayer(PlayerDetailSO playerDetailSO)
    {
        //    _selectionPlayerDetailSO = playerDetailSO;
    }
    public void InstantiatePlayer()
    {
        _currentInstantiatePlayer = Instantiate(_playerInstantiatePrefab, new Vector3(-10, 0), Quaternion.identity);
        _currentInstantiatePlayer.GetComponentInChildren<SpriteRenderer>().color = _selectionPlayerDetailSO.Color;
        //_currentInstantiatePlayer.GoldManger.GameInGoldAmount = 0;
    }
}

public class PlayerInstaller
{
    void InstantiatePlayer()
    {

    }
}
