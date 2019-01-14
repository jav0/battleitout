using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private Text p1Live;
    [SerializeField]
    private Text p2Live;
    [SerializeField]
    private Text p1Energy;
    [SerializeField]
    private Text p2Energy;
    
    [SerializeField]
    private Text sp1Score;
    public int p1Score = 0;
    [SerializeField]
    private Text sp2Score;
    public int p2Score = 0;
    
    [SerializeField]
    private Text time;
    
    [SerializeField]
    private Player p1;
    [SerializeField]
    private Player p2;    
    
    [SerializeField]
    private Text endResult;
    [SerializeField]
    private Text endResultp;
    
    [SerializeField]
    private float timeMax = 300f;
    private float timeLeft;
    
    [SerializeField]
    private GameManager gm;
    
    private float endtimeMax = 5f;
    private float endtimeLeft;
    
    public bool endGame = false;
    
    public void Start()
    {
        SetDefaults();
    }
    
    public void Update()
    {
        p1Live.text = p1.getHealth().ToString();
        p1Energy.text = p1.getEnergy().ToString();
        
        p2Live.text = p2.getHealth().ToString();
        p2Energy.text = p2.getEnergy().ToString();
        
        if (endGame)
        {
            endtimeLeft -= Time.deltaTime;
            
            if (endtimeLeft <= 0f)
            {
                gm.ToMainMenu();
            }
        } else {
            timeLeft -= Time.deltaTime;
        
            if (timeLeft <= 0f)
            {
                gm.EndGame(0);
            }
        }
    }
    
    void SetDefaults()
    {
        p1Live.text = "0";
        p2Live.text = "0";
        p1Energy.text = "0";
        p2Energy.text = "0";
        sp1Score.text = "0";
        sp2Score.text = "0";
        time.text = "0:00";
        endResult.enabled = false;
        endResultp.enabled = false;
        
        timeLeft = timeMax;
        endtimeLeft = endtimeMax;
    }
    
    public void ResetTimer()
    {
        timeLeft = timeMax;        
    }
    
    void OnGUI() {
        int minutes = Mathf.FloorToInt(timeLeft / 60F);
        int seconds = Mathf.FloorToInt(timeLeft - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        time.text = niceTime;
    }
    
    public void IncScore1()
    {
        sp1Score.text = (p1Score + 1).ToString();
        p1Score += 1;
    }
    
    public void IncScore2()
    {
        sp2Score.text = (p2Score + 1).ToString();
        p2Score += 1;
    }
    public void EndGame(string _player)
    {
        if (_player != "0")
            endResult.enabled = true;
        endResultp.enabled = true;
        if (_player == "0")
            endResultp.text = "DRAW";
        else            
            endResultp.text = _player;
        endGame = true;
    }
}
