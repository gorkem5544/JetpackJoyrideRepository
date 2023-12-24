using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts.OtherPools;
using UnityEngine;
public interface IGoldController : IEntityController
{
    Rigidbody2D Rigidbody2D { get; }
}

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class GoldController : LifeCycleController, IGoldController
    {
        Rigidbody2D _rigidbody2D;

        GoldHorizontalMovement _goldHorizontalMovement;
        public Rigidbody2D Rigidbody2D { get => _rigidbody2D; set => _rigidbody2D = value; }
        private void Awake()
        {



            _rigidbody2D = GetComponent<Rigidbody2D>();
            _goldHorizontalMovement = new GoldHorizontalMovement(this);
        }
        private void OnEnable()
        {
            _goldHorizontalMovement.MoveHorizontalWhenEnabled();

        }
        private void Start()
        {
        }
        public override void KillObject()
        {
            GoldPool.Instance.Set(this);
            _currentTime = 0;
        }
        public void Dead()
        {
            KillObject();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.TryGetComponent(out IPlayerController playerController))
            {
                //playerController.GoldManger.IncreaseGoldAmount(1);
                playerController.GoldManger.IncreaseGameInGoldAmount(1);
                KillObject();
            }
        }
    }

}

public class GoldHorizontalMovement : IEntityHorizontalMove
{
    IGoldController _goldController;
    public GoldHorizontalMovement(IGoldController goldController)
    {
        _goldController = goldController;
    }
    public virtual void MoveHorizontalWhenEnabled()
    {
        _goldController.Rigidbody2D.velocity = Vector2.left * 5f;
    }

}