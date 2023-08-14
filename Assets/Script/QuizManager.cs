using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private List<Question> QuestionsDB;
    [SerializeField] private List<Question> Questions;
    [SerializeField] private GameObject[] AnswerButtons;
    private int currentQuestion;
    [SerializeField] private TMP_Text QuestionText;
    [SerializeField] private GameObject GamePlayPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TMP_Text GameResultText;

    private bool isWin;
    private float timer;
    private bool isTiming;
    [SerializeField] private TMP_Text TimeText;
    [SerializeField] private float timeLimit;
    private void Start()
    {
        SetupQuestion();
    }
    private void Update()
    {
        if(isTiming)
        {
            timer += Time.deltaTime;
            if(timer >= timeLimit){
                Wrong();
            }
            TimeText.text = ((int)timeLimit-(int)timer - 1).ToString();
        }
    }
    public void Play()
    {
        SetupQuestion();
        GameOverPanel.SetActive(false);
        GamePlayPanel.SetActive(true);
    }
    void SetupQuestion()
    {
        Questions = new List<Question>(QuestionsDB);
        GenerateQuestion();
    }
    void SetAnswers()
    {
        for(int i = 0; i < AnswerButtons.Length; i++)
        {
            AnswerButtons[i].GetComponentInChildren<TMP_Text>().text = Questions[currentQuestion].answers[i];
        }
    }
    public void Answer()
    {
        isTiming = false;
        string ans = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.tag;
        Debug.Log(ans);
        Debug.Log(Questions[currentQuestion].correctAns);
        if(ans == Questions[currentQuestion].correctAns)
        {
            Debug.Log("vai biu");
            Correct();
        }
        else
        {
            Wrong();
        }
    }
    void GenerateQuestion()
    {
        isTiming = true;
        timer = 0;
        if(Questions.Count > 0)
        {
            currentQuestion = Random.Range(0, Questions.Count);
            
            QuestionText.text = Questions[currentQuestion].questionInfo;
            SetAnswers();
            Debug.Log(currentQuestion);
        }
        else{
            isWin = true;
            GameOver();
        }
    }
    public void Correct()
    {
        Questions.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    public void Wrong()
    {
        isWin = false;
        GameOver();
    }
    void GameOver()
    {
        GamePlayPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        if(isWin)
        {
            GameResultText.text = "YOU WIN";
        }
        else
        {
            GameResultText.text = "YOU LOSE";
        }
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;         //question text
    public List<string> answers;        //options to select
    public string correctAns;           //correct option
}