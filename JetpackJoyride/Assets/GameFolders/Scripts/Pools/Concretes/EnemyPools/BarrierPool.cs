using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierPool : BarrierGenericPool
{
    public override void ResetAllObject()
    {
        foreach (BaseEnemyController child in GetComponentsInChildren<BarrierController>())
        {
            if (!child.gameObject.activeSelf)
            {
                return;
            }
            child.DeadObject();
        }
    }

    // protected override void KillAllObjet()
    // {
    //     foreach (BaseEnemyController child in GetComponentsInChildren<BarrierController>())
    //     {
    //         if (!child.gameObject.activeSelf)
    //         {
    //             return;
    //         }
    //         child.DeadObject();
    //     }
    // }
}
