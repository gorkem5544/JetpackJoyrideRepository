using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "PlayerSO_NEW_DATA", menuName = "JetpackJoyride/PlayerSO_NEW_DATA", order = 0)]
public class newPlayerSO : ScriptableObject
{
    [SerializeField] PlayerController _playerController;

    public IPlayerController PlayerController => _playerController;


    [SerializeField] string _characterName;
    public string CharacterName => _characterName;

}