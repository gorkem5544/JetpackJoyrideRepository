using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class LevelManager : SingletonDontDestroyMonoObject<LevelManager>
    {
        public void LoadLevelScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        public IEnumerator LoadSceneAsync(string sceneName)
        {
            // AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            // while (asyncOperation.progress < 1)
            // {
            //     //PlayerManager.Instance._playerController = Instantiate(PlayerManager.Instance.CurrentPlayer._playerDetailSO.playerController);
            //     Debug.Log(PlayerManager.Instance._playerController);
            //     //PlayerManager.Instance.GetReferancePlayer();
            //     yield return new WaitForEndOfFrame();
            //     PlayerManager.Instance.GetReferancePlayer();

            // }

            yield return SceneManager.LoadSceneAsync(sceneName);
            PlayerManager.Instance.InstantiatePlayer();
        }
    }

}