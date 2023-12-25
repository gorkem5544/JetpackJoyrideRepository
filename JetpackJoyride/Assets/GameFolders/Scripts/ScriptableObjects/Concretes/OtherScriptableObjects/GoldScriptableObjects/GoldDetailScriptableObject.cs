using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.OtherScriptableObjects.GoldScriptableObjects
{


    [CreateAssetMenu(fileName = "GoldDetailScriptableObject", menuName = "JetpackJoyride/GoldDetailScriptableObject", order = 0)]
    public class GoldDetailScriptableObject : ScriptableObject, IHorizontalMoveSpeed
    {
        [SerializeField] float _horizontalMoveSpeed;
        public float HorizontalMoveSpeed => _horizontalMoveSpeed;
    }
}