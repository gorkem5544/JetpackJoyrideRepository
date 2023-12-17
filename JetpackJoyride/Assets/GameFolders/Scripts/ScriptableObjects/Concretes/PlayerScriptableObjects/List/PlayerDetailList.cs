using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerDetailList", menuName = "JetpackJoyride/PlayerDetailList", order = 0)]
public class PlayerDetailList : ScriptableObject
{
    public List<PlayerDetailSO> playerDetailSOs = new List<PlayerDetailSO>();
}