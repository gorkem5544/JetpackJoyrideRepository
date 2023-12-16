using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers
{
    public class CoinController : LifeCycleController
    {
        protected override void KillObject()
        {

        }
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.TryGetComponent(out IPlayerController playerController))
            {
                playerController.GoldManger.IncreaseGold(1);
                KillObject();
            }
        }
    }

}