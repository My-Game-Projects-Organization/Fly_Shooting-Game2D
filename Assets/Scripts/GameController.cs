using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public UIManager m_ui;

    public GameObject enemy;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0; 
        m_ui = FindObjectOfType<UIManager>();
        m_ui.setScoreText("Score: 0");
    }

    // Update is called once per frame
    void Update()
    {

        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);

            return;
        }
        m_spawnTime -= Time.deltaTime;

        if(m_spawnTime <= 0)
        {
            spawnEnemy();

            m_spawnTime = spawnTime;
        }
    }

    public void spawnEnemy()
    {
        float randomXpos = Random.Range(-6f, 6f);

        Vector2 spawnPos = new Vector2(randomXpos, 6);

        if (enemy)
        {
            Instantiate(enemy,spawnPos,Quaternion.identity);
        }
    }

    public void replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void setScore(int value)
    {
        m_score = value;
    }
    public int getScore()
    {
        return m_score;
    }

    public void setIsGameOverState(bool state)
    {
        m_isGameOver = state;
    }

    public bool isGameOver()
    {
        return m_isGameOver;
    }

    public void scoreIncrement()
    {
        if (m_isGameOver)
            return;

        m_score++;
        m_ui.setScoreText("Score: " + m_score);
    }
}
