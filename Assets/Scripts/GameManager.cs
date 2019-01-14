using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player1;
    [SerializeField]
    private Player player2;
    [SerializeField]
    private GameObject gameUI;
    
    private GameUI UI;
    private bool endGame = false;
    
    public void Start()
    {
        UI = gameUI.GetComponent<GameUI>();
    }
    
    public void Update()
    {
        if (endGame)
            return;
        
        if (player1.getHealth() == 0)
        {
            UI.IncScore2();
            if (UI.p2Score >= 3)
            {
                EndGame(2);
            }
            NewRound();
        }
        if (player2.getHealth() == 0)
        {
            UI.IncScore1();
            if (UI.p1Score >= 3)
            {
                EndGame(1);
            }
            NewRound();
        }
    }
    
    public void NewRound()
    {
        player1.SetDefaults();
        player2.SetDefaults();
    }
    
    public void EndGame(int _case)
    {
        if (_case == 0)
        {
            if (UI.p2Score > UI.p1Score)
            {
                UI.EndGame("2");
            }
            if (UI.p2Score < UI.p1Score)
            {
                UI.EndGame("1");
            }
            if (UI.p2Score == UI.p1Score)
            {
                // Draw
                UI.EndGame("0");
            }
        }
        if (_case == 1)
        {
            UI.EndGame("1");
        }
        if (_case == 2)
        {
            UI.EndGame("2");
        }
        endGame = true;
    }
    
    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
}
