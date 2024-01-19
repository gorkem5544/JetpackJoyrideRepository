using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts.OtherPools;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.OtherScriptableObjects.GoldScriptableObjects;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class GoldController : LifeCycleController, IGoldController, IGoldHorizontalMoveWithRigidBody2D
    {
        IGoldHorizontalMove _goldHorizontalMove;

        Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        [SerializeField] GoldDetailScriptableObject _goldDetailScriptableObject;
        public float HorizontalMoveSpeed => _goldDetailScriptableObject.HorizontalMoveSpeed;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _goldHorizontalMove = new GoldHorizontalMoveWithRigidBody2D(this);
        }
        private void OnEnable()
        {
            _goldHorizontalMove.HorizontalMoveTick();
        }
        public override void KillObject()
        {
            GoldPool.Instance.Set(this);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPlayerController playerController))
            {
                playerController.GoldManger.IncreaseGameInGoldAmount(1);
                KillObject();
            }
        }
    }
}

