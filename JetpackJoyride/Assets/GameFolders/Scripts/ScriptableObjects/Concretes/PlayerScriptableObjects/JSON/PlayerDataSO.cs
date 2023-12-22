using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "JetpackJoyride/PlayerStats", order = 0)]
public class PlayerDataSO : ScriptableObject
{
    public int Score { get; set; }
}