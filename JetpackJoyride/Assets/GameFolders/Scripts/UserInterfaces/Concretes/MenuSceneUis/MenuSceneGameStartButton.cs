using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis
{
    public class MenuSceneGameStartButton : BaseButton
    {
        protected override void ButtonOnClick()
        {
            LevelManager.Instance.LoadLevelScene("Game");
        }
    }

}