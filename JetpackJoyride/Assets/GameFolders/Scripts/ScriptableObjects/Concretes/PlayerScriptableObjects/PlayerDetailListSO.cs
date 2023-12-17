using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerDetailListSO", menuName = "JetpackJoyride/PlayerDetailListSO", order = 0)]
public class PlayerDetailListSO : ScriptableObject
{
    public List<PlayerDetailSO> playerDetailSOs;
}