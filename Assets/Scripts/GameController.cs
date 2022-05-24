using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _fillPrefab;
    [SerializeField] Cell2048 [] _allCells;
    public static Action<string> _slide;
    public static GameController instance;
    public static int ticker;
    public int myScore;
    [SerializeField] Text _scoreText;
    int isGameOver;
    [SerializeField] GameObject _gameOverPanel;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void SpawnFill()
    {
        bool isFull = true;
        for (int i = 0; i < _allCells.Length; i++)
        {
            if (_allCells[i]._fill == null)
            {
                isFull = false;
            }
        }

        if (isFull)
        {
            return;
        }
        int whichSpawn = UnityEngine.Random.Range(0, _allCells.Length);
        if (_allCells[whichSpawn].transform.childCount != 0 )
        {
            Debug.Log(_allCells[whichSpawn] + " " + " is already filled");
            SpawnFill();
            return;
        }
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log("Chance" + chance);
        if (chance<0.2)
        {
            return;
        }

        else if (chance <0.8)
        {
            
            GameObject _tempFill = Instantiate(_fillPrefab, _allCells[whichSpawn].transform);
            Debug.Log(2);
            Fill2048 _fillTemp = _tempFill.GetComponent<Fill2048>();
            _allCells[whichSpawn].GetComponent<Cell2048>()._fill = _fillTemp; 
            _fillTemp.FillValueUpdate(2);
        }

        else
        {
            
            GameObject _tempFill = Instantiate(_fillPrefab, _allCells[whichSpawn].transform);
            Fill2048 _fillTemp = _tempFill.GetComponent<Fill2048>();
            _allCells[whichSpawn].GetComponent<Cell2048>()._fill = _fillTemp;
            _fillTemp.FillValueUpdate(4);
        }
    }

    public void StartSpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, _allCells.Length);
        if (_allCells[whichSpawn].transform.childCount != 0)
        {
            Debug.Log(_allCells[whichSpawn] + " " + " is already filled");
            SpawnFill();
            return;
        }
        

            GameObject _tempFill = Instantiate(_fillPrefab, _allCells[whichSpawn].transform);
            Debug.Log(2);
            Fill2048 _fillTemp = _tempFill.GetComponent<Fill2048>();
            _allCells[whichSpawn].GetComponent<Cell2048>()._fill = _fillTemp;
            _fillTemp.FillValueUpdate(2);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFill();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ticker = 0;
            isGameOver = 0;
            _slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ticker = 0;
            isGameOver = 0;
            _slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ticker = 0;
            isGameOver = 0;
            _slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ticker = 0;
            isGameOver = 0;
            _slide("a");
        }
    }

    private void Start()
    {
        StartSpawnFill();
        StartSpawnFill();
        StartSpawnFill();
    }

    public void ScoreUpdate(int scoreIn)
    {
        myScore += scoreIn;
        _scoreText.text = myScore.ToString();
    }

    public void GameOverCheck()
    {
        isGameOver++;

        if (isGameOver >=16)
        {
            _gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
