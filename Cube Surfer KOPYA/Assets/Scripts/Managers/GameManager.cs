using UnityEngine;
using System;

namespace Managers
{
    public enum GameStates
    {
        GAME,
        MENU,
        LEVELCOMPLETE,
        GAMEOVER
    }

    public class GameManager :MonoBehaviour
    {
        public static GameManager Instance;
        public static event Action<GameStates> OnGameStateChange;
        public LevelManager LevelManager;
        public CanvasManager canvasManager;


        private GameStates _gameState;
        public GameStates GameState
        {
            get
            {
                return _gameState;
            }
            set
            {
                _gameState = value;
                OnGameStateChange?.Invoke(value);
            }
        }


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            canvasManager.SetLoading();
            LevelManager.LastLevel();
        }

        // Set Game States
        public void SetGame()
        {
            GameState = GameStates.GAME;
            canvasManager.SetGame();
            Debug.Log(GameState);
        }

        public void SetMenü()
        {
            GameState = GameStates.MENU;
            canvasManager.SetMenü();
            Debug.Log(GameState);
        }

        public void SetLevelComplete()
        {
            GameState = GameStates.LEVELCOMPLETE;
            canvasManager.SetLevelComolete();
            Debug.Log(GameState);
        }

        public void SetGameOver()
        {
            GameState = GameStates.GAMEOVER;
            canvasManager.SetGameOver();
            Debug.Log(GameState);
        }

    }
}
