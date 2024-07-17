using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis
{
    public class GameStartButtonInMenuScene : BaseButton
    {
        LevelManager _levelManager;
        public void Installer(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }
        protected override void ButtonOnClick()
        {
            _levelManager.LoadLevel("Game");
        }
    }

}