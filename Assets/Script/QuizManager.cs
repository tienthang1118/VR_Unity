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

    private Answer answer;
    private void Start()
    {
        isTiming = false;
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
            AnswerButtons[i].GetComponent<Image>().color = Color.white;
            AnswerButtons[i].GetComponentInChildren<TMP_Text>().text = Questions[currentQuestion].answers[i];
            if(Questions[currentQuestion].correctAns == i+1)
            {
                AnswerButtons[i].GetComponent<Answer>().IsCorrect(true);
            }
            else
            {
                AnswerButtons[i].GetComponent<Answer>().IsCorrect(false);
            }
        }
    }
 
    void GenerateQuestion()
    {
        if(Questions.Count > 0)
        {
            timer = 0;
            isTiming = true;
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
        if(isTiming){
            isTiming = false;
            StartCoroutine(CorrectAns());
        }
    }
    public void Wrong()
    {
        if(isTiming){
            isTiming = false;
            StartCoroutine(WrongAns());
        }
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
    IEnumerator CorrectAns()
    {
        yield return new WaitForSeconds(1);
        Questions.RemoveAt(currentQuestion);
        GenerateQuestion();
    }
    IEnumerator WrongAns()
    {
        yield return new WaitForSeconds(1);
        Questions.RemoveAt(currentQuestion);
        isWin = false;
        GameOver();
    }
    public bool IsTiming()
    {
        return isTiming;
    }
}

[System.Serializable]
public class Question
{
    public string questionInfo;         //question text
    public List<string> answers;        //options to select
    public int correctAns;           //correct option
}