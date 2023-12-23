using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

public class ReturnMenuButton : BaseButton
{
    protected override void ButtonOnClick()
    {
        LevelManager.Instance.LoadMenuScene("Menu");
    }

}
