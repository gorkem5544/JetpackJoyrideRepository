using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects
{

    [CreateAssetMenu(fileName = "EnemyBarrierSO", menuName = "JetpackJoyride/EnemyBarrierSO", order = 0)]
    public class EnemyBarrierSO : ScriptableObject, IHorizontalMoveSpeed
    {
        [SerializeField] float _horizontalMoveSpeed;
        public float HorizontalMoveSpeed => _horizontalMoveSpeed;
    }
}