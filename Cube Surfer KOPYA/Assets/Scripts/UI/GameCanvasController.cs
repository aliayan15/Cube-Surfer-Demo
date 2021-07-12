using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{

    public class GameCanvasController : MonoBehaviour
    {
        [SerializeField] private Text level;

        public void ShowLevel()
        {
            var level = GameManager.Instance.LevelManager.GetGameLevel();
            this.level.text = "Level: " + level;
        }
    }
}

