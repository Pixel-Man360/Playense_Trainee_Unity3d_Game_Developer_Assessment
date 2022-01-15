using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action<bool> OnGameStartedorEnded;

    public enum GameState
    {
        Started,
        Ended
    }

    private GameState _gameState;
    
    void Awake()
    {
        _gameState = GameState.Started;
    }

    
    void Update()
    {

        switch (_gameState)
        {
            case GameState.Started:

            if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                OnGameStartedorEnded?.Invoke(true);
            }

            break;

            case GameState.Ended:
             
             OnGameStartedorEnded?.Invoke(false);

            break;

        }
        
    }

    public void ChangeState(GameState state) => _gameState = state;
}
