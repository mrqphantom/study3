using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameover;
    GameUI UI;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        UI = FindObjectOfType<GameUI>();
        UI.SetscoreText("score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {   if(m_isGameover)
        {
            m_spawnTime = 0;
            UI.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <=0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
        
    }
    public void SpawnEnemy()
    {
        float randXpos = Random.Range(-7f, 7f);
        Vector2 randPos = new Vector2(randXpos, 7f);
        if (enemy)
        {
            Instantiate(enemy, randPos, Quaternion.identity);
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene("Pilotgame");
    }
    public void Setscore(int value)
    {
        m_score = value;
    }
    public int Getscore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        m_score++;

    }
    public void SetGameoverSate(bool state)
    {
        m_isGameover = state;
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
}
