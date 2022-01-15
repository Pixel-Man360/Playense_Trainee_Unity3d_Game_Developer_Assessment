using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("Dependecies: ")]
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _tapToStartText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TextMeshProUGUI _coinCounter;

    private int _coinsCollected;

    void Awake()
    {
       _tapToStartText.SetActive(true);
       _gameOverPanel.SetActive(false); 
       _restartButton?.onClick.AddListener(RestartGame);
    }

    void Start()
    {
        _coinsCollected = 0;
    }

    void OnEnable() 
    {
        GameManager.OnGameStartedorEnded += GamePlayUIController;
        Coins.OnCoinCollected += CountCoins;
    }

    void OnDisable() 
    {
        GameManager.OnGameStartedorEnded -= GamePlayUIController;
        Coins.OnCoinCollected -= CountCoins;
    }

    void GamePlayUIController(bool startedOrEnded)
    {
        if(startedOrEnded)
        {
            _tapToStartText.SetActive(false);
        }

        else
        {
            _gameOverPanel.SetActive(true);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void CountCoins() 
    {
        _coinsCollected++;
        _coinCounter.SetText(_coinsCollected.ToString());
    }
    
}
