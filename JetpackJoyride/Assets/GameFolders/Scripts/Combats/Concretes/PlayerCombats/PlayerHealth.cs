using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats
{
    public class PlayerHealth : MonoBehaviour
    {
        public System.Action OnDead { get; set; }
        public System.Action OnReSpawn { get; set; }
        public void TakeHit()
        {
            OnDead?.Invoke();
        }
        public void ReSpawn()
        {
            OnReSpawn?.Invoke();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out IEnemyController enemyController))
            {
                TakeHit();
                BarrierPool.Instance.SetPool(enemyController.transform.GetComponent<BarrierController>());
            }
        }
    }

}