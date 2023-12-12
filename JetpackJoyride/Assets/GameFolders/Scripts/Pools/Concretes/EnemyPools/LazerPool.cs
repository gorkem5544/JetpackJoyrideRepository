using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Concretes.Pools
{
    public class LazerPool : GenericPool<LazerController>
    {
        public static LazerPool Instance { get; private set; }
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
