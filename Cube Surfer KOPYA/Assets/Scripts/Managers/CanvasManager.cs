using UnityEngine;
using UI;

namespace Managers
{
    public class CanvasManager : MonoBehaviour
    {
        // Panels
        [SerializeField] private GameObject gameOver;
        [SerializeField] private GameObject levelCoplete;
        [SerializeField] private GameObject loadingPanel;
        [SerializeField] private GameObject men�Panel;
        [SerializeField] private GameObject gamePanel;

        public void SetGameOver()
        {
            gameOver.SetActive(true);
            levelCoplete.SetActive(false);
            loadingPanel.SetActive(false);
            men�Panel.SetActive(false);
            gamePanel.SetActive(true);
        }
        public void SetLevelComolete()
        {
            gameOver.SetActive(false);
            levelCoplete.SetActive(true);
            loadingPanel.SetActive(false);
            men�Panel.SetActive(false);
            gamePanel.SetActive(true);
        }
        public void SetLoading()
        {
            gameOver.SetActive(false);
            levelCoplete.SetActive(false);
            loadingPanel.SetActive(true);
            men�Panel.SetActive(false);
            gamePanel.SetActive(false);
            gamePanel.SetActive(false);
        }
        public void SetMen�()
        {
            gameOver.SetActive(false);
            levelCoplete.SetActive(false);
            loadingPanel.SetActive(false);
            men�Panel.SetActive(true);
            gamePanel.SetActive(true);
            gamePanel.GetComponent<GameCanvasController>().ShowLevel();
        }
        public void SetGame()
        {
            gameOver.SetActive(false);
            levelCoplete.SetActive(false);
            loadingPanel.SetActive(false);
            men�Panel.SetActive(false);
            gamePanel.SetActive(true);
        }
    }
}
