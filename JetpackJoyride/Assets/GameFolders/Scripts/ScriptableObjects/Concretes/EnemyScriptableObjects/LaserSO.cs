using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.EnemyScriptableObjects
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "LaserSO", menuName = "JetPackJoyride/LaserSO", order = 0)]
    public class LaserSO : ScriptableObject
    {

        [Header("Laser Bodies")]
        [SerializeField] Transform _top;
        [SerializeField] GameObject _down;
        [SerializeField] GameObject _center;
        [Header("Target Positions")]
        [SerializeField] Transform _topTarget;
        [SerializeField] Transform _downTarget;

        public Transform Top { get => _top; set => _top = value; }
        public GameObject Down { get => _down; set => _down = value; }
        public GameObject Center { get => _center; set => _center = value; }
        public Transform TopTarget { get => _topTarget; set => _topTarget = value; }
        public Transform DownTarget { get => _downTarget; set => _downTarget = value; }
    }
}