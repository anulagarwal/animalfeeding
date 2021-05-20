using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    [Header("Panel References")]
    public GameObject MainMenu;
    public GameObject InGame;
    public GameObject WinPanel;
    public GameObject LosePanel;

    [Header("Component References")]
    [SerializeField] private GameObject AwesomeText;


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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLevelText()
    {

    }

    public void SpawnAwesomeText(string s, Vector3 pos)
    {
        GameObject g = Instantiate(AwesomeText, pos, Quaternion.identity);
        g.GetComponent<AwesomeText>().SetText(s);
    }

    public void UpdateState(GameManager.State state)
    {
        switch (state)
        {
            case GameManager.State.MainMenu:
                MainMenu.SetActive(true);
                InGame.SetActive(false);
                WinPanel.SetActive(false);
                LosePanel.SetActive(false);
                break;

            case GameManager.State.InGame:
                MainMenu.SetActive(false);
                InGame.SetActive(true);
                WinPanel.SetActive(false);
                LosePanel.SetActive(false);
                break;

            case GameManager.State.Win:
                MainMenu.SetActive(false);
                InGame.SetActive(false);
                WinPanel.SetActive(true);
                LosePanel.SetActive(false);
                break;

            case GameManager.State.Lose:
                MainMenu.SetActive(false);
                InGame.SetActive(false);
                WinPanel.SetActive(false);
                LosePanel.SetActive(true);
                break;

        }
    }
}
