using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class ScoreManager : SingletonDontDestroyMonoObject<ScoreManager>
    {
        private const string PLAYER_HIGH_SCORE_KEY = "HighScore";

        /// <summary>
        /// Parametre olarak gelen "currentScore" değeri "GetScore()" float değeri döndüren methodundan yüksek ise 
        /// </summary>
        /// <param name="currentScore"></param>
        public void SaveScore(float currentScore)
        {
            if (currentScore > GetScore())
            {
                string saveScore = JsonConvert.SerializeObject(currentScore);
                PlayerPrefs.SetString(PLAYER_HIGH_SCORE_KEY, saveScore);
            }
        }
        public float GetScore()
        {
            if (PlayerPrefs.HasKey(PLAYER_HIGH_SCORE_KEY))
            {
                string getScore = PlayerPrefs.GetString(PLAYER_HIGH_SCORE_KEY);
                return JsonConvert.DeserializeObject<float>(getScore);
            }
            else
            {
                return 0;
            }
        }
    }

}