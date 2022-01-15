using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDone : MonoBehaviour
{
    [Header("Dependencies: ")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Transform _player;

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name == "Player")
        {
            _gameManager.ChangeState(GameManager.GameState.Ended);
        }
    }

    void Update() 
    {
        if(_player.position.y < -4f)
        {
            _gameManager.ChangeState(GameManager.GameState.Ended);
        }
    }
}
