using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class LevelManager : MonoBehaviour
    {
        public static event System.Action<string> OnLevelLoaded;
        public static event System.Action<string> OnLevelUnloaded;
        public static event System.Action<string> OnLevelLoadingStarted;

        public void LoadLevel(string sceneName)
        {
            StartCoroutine(LoadSceneAsync(sceneName));
        }

        public void UnloadLevel(string sceneName)
        {
            StartCoroutine(UnloadSceneAsync(sceneName));
        }

        private IEnumerator LoadSceneAsync(string sceneName)
        {
            OnLevelLoadingStarted?.Invoke(sceneName);

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            OnLevelLoaded?.Invoke(sceneName);
            GameManager.Instance.ChangeGameState(GameManagerStateEnum.GameState);
        }

        private IEnumerator UnloadSceneAsync(string sceneName)
        {
            AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);

            while (asyncUnload != null && !asyncUnload.isDone)
            {
                yield return null;
            }
            {
                yield return null;
            }

            OnLevelUnloaded?.Invoke(sceneName);
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