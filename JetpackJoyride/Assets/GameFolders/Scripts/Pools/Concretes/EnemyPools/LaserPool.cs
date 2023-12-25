using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Concretes.Pools
{
    public class LaserPool : GenericPool<LaserController>
    {
        public static LaserPool Instance { get; private set; }

        public override void ResetAllObject()
        {
            foreach (LaserController laserController in GetComponentsInChildren<LaserController>())
            {
                if (!laserController.gameObject.activeSelf)
                {
                    return;
                }
                laserController.KillEnemyController();
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
