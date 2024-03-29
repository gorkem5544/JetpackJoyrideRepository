using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Enums.PlayerEnums;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerDetailSO", menuName = "JetpackJoyride/PlayerDetailSO", order = 0)]
public class PlayerDetailSO : ScriptableObject
{
    public string playerCharacterName;
    public Color Color;
    //public PlayerController playerController;
    public PlayerTypeEnum PlayerTypeEnum;

}