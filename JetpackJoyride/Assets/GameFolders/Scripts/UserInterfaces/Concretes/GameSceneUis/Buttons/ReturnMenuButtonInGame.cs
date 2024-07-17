using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

public class ReturnMenuButtonInGame : BaseButton
{
    LevelManager _levelManager;
    public void Installer(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    protected override void ButtonOnClick()
    {
        _levelManager.LoadLevel("Menu");
        _levelManager.UnloadLevel("Game");

    }

}
