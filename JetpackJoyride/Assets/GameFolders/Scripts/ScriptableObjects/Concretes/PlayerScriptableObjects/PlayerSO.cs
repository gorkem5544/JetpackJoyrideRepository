using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "JetpackJoyride/PlayerSO", order = 0)]
    public class PlayerSO : ScriptableObject
    {
        [SerializeField] float _forceSpeed;

        public float ForceSpeed => _forceSpeed;


        
    }
}