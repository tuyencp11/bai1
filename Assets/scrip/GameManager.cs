using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public int Score=0;
    [SerializeField] float delayenemy;
    float timespaw;
    [SerializeField] Text Score_Text;
    public GameObject pnlEndGame;
    public Button btnRestart;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Score_Text.text = "Score:" + Score.ToString();
        SpawEnemy();

    }
    void SpawEnemy()
    {
        if (timespaw > 0)
        {
            timespaw -= Time.deltaTime;
            return;
        }
        enemyPooling.Instant.Get_Obj();
        timespaw = delayenemy;
    }
    public void EndGame()
    {
        pnlEndGame.SetActive(true);
    }
 
}
