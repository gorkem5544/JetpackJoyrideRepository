using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentPlayer", menuName = "JetpackJoyride/CurrentPlayer", order = 0)]
public class CurrentPlayer : ScriptableObject
{
    public PlayerDetailSO _playerDetailSO;
    public string playerName;
}