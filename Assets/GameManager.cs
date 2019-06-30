using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private Text scoreTxt;

    [SerializeField]
    private Transform objbox;

    [SerializeField]
    private Text bestScore;

    [SerializeField]
    private GameObject panel;

    private int score;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool stopTrigger = true;
    public void GameOver()
    {
        Debug.Log("game over");
        stopTrigger = false;
        StopCoroutine(coroutine);

        if (score >= PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SetInt("BestScore", score);

        bestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        panel.SetActive(true);
    }

    public void GameStart()
    {
        score = 0;
        scoreTxt.text = "Score : " + score;
        stopTrigger = true;
        coroutine = CreateFireRoutine();
        StartCoroutine(coroutine);
        panel.SetActive(false);
    }
    public void Score()
    {
        score++;
        scoreTxt.text = "Score : " + score;
    }

    IEnumerator CreateFireRoutine()
    {
        while (true)
        {
            CreateFire();
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void CreateFire()
    {
        //Debug.Log("create fire");
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 5.0f));
        //pos.z = 0.0f;
        Instantiate(fire, pos, Quaternion.identity);
    }
}
