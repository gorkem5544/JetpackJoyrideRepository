using System.Collections;
using System.Collections.Generic;
using Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Abstracts.Texts;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.UserInterfaces.Concretes.MenuSceneUis
{
    public class MenuSceneHighScoreText : BaseHighScoreText
    {
        private void Start() => WriteHighScoreValueIntoText();
    }
}
