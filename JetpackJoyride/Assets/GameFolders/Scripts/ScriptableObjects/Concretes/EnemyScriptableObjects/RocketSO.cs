using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects
{


    [CreateAssetMenu(fileName = "RocketSO", menuName = "JetpackJoyride/RocketSO", order = 0)]
    public class RocketSO : ScriptableObject, IMoveSpeedSOService
    {
        [SerializeField] float _horizontalMoveSpeed;
        public float HorizontalMoveSpeed => _horizontalMoveSpeed;
    }
}