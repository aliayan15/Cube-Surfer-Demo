using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public List<GameObject> PlayerKüpleri = new List<GameObject>();
        [SerializeField] private float Speed = 0.6f;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject cubePrefab;

        private Touch _touch;

        void Update()
        {
            if (PlayerKüpleri.Count <= 0)
            {
                GameManager.Instance.SetGameOver();
            }
            if (GameManager.Instance.GameState != GameStates.GAME)
                return;

            MovePlayer();
            Limitation();
            Debug.Log(PlayerKüpleri.Count);
        }

        private void Limitation()
        {
            Vector3 pos = transform.position;
            if (pos.x >= 1.2f)
            {
                pos.x = 1.2f;
            }
            if (pos.x <= -0.9f)
            {
                pos.x = -0.9f;
            }
            transform.position = pos;
        }
        private void MovePlayer()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + _touch.deltaPosition.x * Speed * Time.deltaTime,
                        transform.position.y,
                        transform.position.z);
                }

            }
        }

        public void AddCube()
        {
            Vector3 playerPos = player.transform.position;
            player.transform.position = new Vector3(playerPos.x, playerPos.y + 0.6f, playerPos.z);
            Vector3 küpPos = new Vector3(PlayerKüpleri[PlayerKüpleri.Count - 1].transform.position.x, player.transform.position.y - 0.27f, PlayerKüpleri[PlayerKüpleri.Count - 1].transform.position.z);
            GameObject küp = Instantiate(cubePrefab, küpPos, Quaternion.identity);
            küp.transform.parent = transform;
        }

    }
}
