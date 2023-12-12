using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts.OtherPools
{
    public class CoinPool : GenericPool<CoinController>
    {
        public static CoinPool Instance { get; set; }
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