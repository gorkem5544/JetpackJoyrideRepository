using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Concretes.Pools
{
    public class LazerPool : GenericPool<LazerController>
    {
        public static LazerPool Instance { get; private set; }

        public override void ResetAllObject()
        {
            foreach (LazerController lazerController in GetComponentsInChildren<LazerController>())
            {
                if (!lazerController.gameObject.activeSelf)
                {
                    return;
                }
                lazerController.DeadObject();
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
