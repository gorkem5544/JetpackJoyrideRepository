using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerDetailSO", menuName = "JetpackJoyride/PlayerDetailSO", order = 0)]
public class PlayerDetailSO : ScriptableObject
{
    public string playerCharacterName;
    public PlayerController playerController;
    private PlayerTypeEnum playerTypeEnum;
    public PlayerTypeEnum PlayerTypeEnum { get => playerTypeEnum; set => playerTypeEnum = value; }

}