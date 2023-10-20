using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPool : GenericPool<BarrierController>
{
    public static BarrierPool Instance { get; private set; }
    public override void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(Instance);
        }
    }
}
