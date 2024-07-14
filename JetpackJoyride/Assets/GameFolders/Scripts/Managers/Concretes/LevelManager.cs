using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class LevelManager : SingletonDontDestroyMonoObject<LevelManager>
    {
        PlayerManager playerManager;
        public void Initialize(PlayerManager manager)
        {
            playerManager = manager;
        }

        public void LoadLevelScene(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        public IEnumerator LoadSceneAsync(string sceneName)
        {
            //syncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            //hile (asyncOperation.progress < 1)
            //
            //   PlayerManager.Instance.InstantiatePlayer();
            //   //PlayerManager.Instance.GetReferancePlayer();
            //   yield return new WaitForEndOfFrame();

            //

            yield return SceneManager.LoadSceneAsync(sceneName);
            GameManager.Instance.ChangeGameState(GameManagerStateEnum.GameState);
            // PlayerManager.Instance.InstantiatePlayer();
            //playerManager.InstantiatePlayer();

        }
        public void LoadMenuScene(string sceneName)
        {
            StartCoroutine(LoadMenuAsync(sceneName));
        }
        private IEnumerator LoadMenuAsync(string sceneName)
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
            // GoldManager.Instance.PlayerPrefsGetScore();
            GameManager.Instance.ChangeGameState(GameManagerStateEnum.MenuState);

        }
    }

}