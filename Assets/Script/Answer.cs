using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

    public void CheckAnswer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Wrong");
            quizManager.Wrong();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
