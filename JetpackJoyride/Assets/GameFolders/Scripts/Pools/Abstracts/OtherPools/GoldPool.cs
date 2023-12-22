using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Controllers.Concretes.OtherControllers;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Pools.Abstracts.OtherPools
{
    public class GoldPool : GenericPool<GoldController>
    {
        public static GoldPool Instance { get; set; }

        public override void ResetAllObject()
        {
            foreach (GoldController child in GetComponentsInChildren<GoldController>())
            {
                if (!child.gameObject.activeSelf)
                {
                    return;
                }
                child.Dead();
            }

        }

        public override void Singleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}