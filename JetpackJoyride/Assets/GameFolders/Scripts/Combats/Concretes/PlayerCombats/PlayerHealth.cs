using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

public interface IPlayerHealth
{

}
namespace Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats
{
    public class PlayerHealth : MonoBehaviour
    {
        public System.Action PlayerHitEvent { get; set; }
        public System.Action PlayerReviveEvent { get; set; }
        public int HitCount { get; private set; }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.GetComponent<IEnemyController>() != null)
            {
                HitCount++;
                PlayerHitEvent?.Invoke();
                 GameManager.Instance.ChangeGameState(GameManagerState.GameOverState);
            }
        }
    }

}