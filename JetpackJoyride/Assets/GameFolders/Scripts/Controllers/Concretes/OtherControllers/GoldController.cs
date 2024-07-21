using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Movements.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts.OtherPools;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.OtherScriptableObjects.GoldScriptableObjects;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class GoldController : LifeCycleController, IGoldController
    {

        Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        [SerializeField] GoldDetailScriptableObject _goldDetailScriptableObject;
        public GoldDetailScriptableObject GoldDetailScriptableObject => _goldDetailScriptableObject;
        IGoldHorizontalMove _goldHorizontalMove;
        GoldHorizontalMoveService _goldHorizontalMoveService;
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _goldHorizontalMoveService = new GoldHorizontalMoveService(this);
            _goldHorizontalMove = new GoldHorizontalMoveWithRigidBody2D(_goldHorizontalMoveService);
        }
        private void OnEnable()
        {
            //_goldHorizontalMove.FixedTick();

        }
        private void FixedUpdate()
        {
            _goldHorizontalMove.FixedTick();
        }
        public override void KillObject()
        {
            GoldPool.Instance.Set(this);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IPlayerController playerController))
            {
                playerController.GoldManger.GameInIncreaseGoldAmount(1);
                KillObject();
            }
        }
    }
}

