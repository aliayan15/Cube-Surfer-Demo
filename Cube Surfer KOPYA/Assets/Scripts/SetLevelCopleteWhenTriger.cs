using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

namespace Utility
{
    public class SetLevelCopleteWhenTriger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && GameManager.Instance.GameState == GameStates.GAME)
                GameManager.Instance.SetLevelComplete();
        }
    }
}
