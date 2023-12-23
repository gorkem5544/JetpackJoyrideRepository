using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Abstracts.Texts;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.GameSceneUis.Texts
{
    public class HighScoreInfoText : BaseHighScoreText
    {
        private void Update() => WriteHighScoreValueIntoText();
    }

}