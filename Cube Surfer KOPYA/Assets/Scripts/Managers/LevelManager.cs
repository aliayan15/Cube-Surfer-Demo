using UnityEngine.SceneManagement;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private string _levelIndex = "levelIndex";
        public void LoadNextLevel()
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(index + 1);
            // Save level index
            SaveLevelIndex(index + 1);
        }

        public void LoadCurrentLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void LastLevel()
        {
            // Load last played level or first level
            if (PlayerPrefs.HasKey(_levelIndex))
            {
                SceneManager.LoadSceneAsync(PlayerPrefs.GetInt(_levelIndex));
            }
            else
            {
                SceneManager.LoadSceneAsync(1);
            }

        }

        public float GetGameLevel()
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            var gameLevel = (float)index;
            return gameLevel;
        }

        private void SaveLevelIndex(int index)
        {
            PlayerPrefs.SetInt(_levelIndex, index);
        }

    }
}
