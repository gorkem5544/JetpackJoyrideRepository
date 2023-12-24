using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Concretes.EnemyPools
{
    public class RocketPool : GenericPool<RocketController>
    {
        public static RocketPool Instance { get; private set; }
        public override void ResetAllObject()
        {
            foreach (var item in GetComponentsInChildren<RocketController>())
            {
                if (!item.gameObject.activeSelf)
                {
                    return;
                }
                item.KillObject();
            }
        }

        public override void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }

}