using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Assembly_CSharp.Assets.GameFolders.Scripts.Managers.Concretes
{
    public class ScoreManager : SingletonDontDestroyMonoObject<ScoreManager>
    {
        private const string PLAYER_HIGH_SCORE_KEY = "HighScore";
        string _saveScore, _getScore;

        public float CurrentScore { get; set; }

        /// <summary>
        /// Parametre olarak gelen "currentScore" değeri "GetScore()" float değeri döndüren methodundan yüksek ise 
        /// </summary>
        /// <param name="currentScore"></param>
        public void SaveScore(float currentScore)
        {
            CurrentScore = currentScore;
            if (currentScore > GetScore())
            {
                _saveScore = JsonConvert.SerializeObject(currentScore);
                PlayerPrefs.SetString(PLAYER_HIGH_SCORE_KEY, _saveScore);
            }
        }
        public float GetScore()
        {
            if (PlayerPrefs.HasKey(PLAYER_HIGH_SCORE_KEY))
            {
                _getScore = PlayerPrefs.GetString(PLAYER_HIGH_SCORE_KEY);
                return JsonConvert.DeserializeObject<float>(_getScore);
            }
            else
            {
                return 0;
            }
        }


    }

}