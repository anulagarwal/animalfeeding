using System.Collections;
using System.Collections.Generic;
using D2D.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private bool _gameStarted;
    
    public static GameManager Instance = null;

    public enum State { MainMenu, InGame, Win, Lose};
    #region Attributes

    [Header ("Attributes")]
    public bool isPaused;

    [Header("Component Reference")]
    public GameObject confetti;
    public Transform escapePos;
    public GameObject sphere;



    [Header("GameplayStates")]
    public State gameState;

    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    // Start is called before the first frame update

    #region Monobehaviour functions
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DInput.IsMousePressed)
            StartLevel();
    }

    #endregion


    public void StartLevel()
    {
        if (_gameStarted)
            return;

        _gameStarted = true;
        
        ChangeState(State.InGame);
        AnimalManager.Instance.EnableAnimals();
    }

    public void WinLevel()
    {
        ChangeState(State.Win);
        confetti.SetActive(true);
        AnimalManager.Instance.DisableAnimals();
    }

    public void LoseLevel()
    {
        ChangeState(State.Lose);
        AnimalManager.Instance.DisableAnimals();
    }

    public void ChangeState(State state)
    {
        gameState = state;
        UIManager.Instance.UpdateState(state);
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }


}
