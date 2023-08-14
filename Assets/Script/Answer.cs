using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Answer : MonoBehaviour
{
    public QuizManager quizManager;
    private bool isCorrect;

    public void IsCorrect(bool status)
    {
        isCorrect = status;
    }
    // public void OnPointerEnter()
    // {
    //     if(gameObject.tag == "Answer" && quizManager.IsTiming())
    //     {
    //         if(isCorrect)
    //         {
    //             gameObject.GetComponent<Image>().color = Color.green;
    //             quizManager.Correct();
    //         }
    //         else
    //         {
    //             gameObject.GetComponent<Image>().color = Color.red;
    //             quizManager.Wrong();
    //         }
    //     }
    //     else if(gameObject.tag == "Play")
    //     {
    //         quizManager.Play();
    //     }
    // }
    public void OnPointerClick()
    {
        if(gameObject.tag == "Answer" && quizManager.IsTiming())
        {
            if(isCorrect)
            {
                gameObject.GetComponent<Image>().color = Color.green;
                quizManager.Correct();
            }
            else
            {
                gameObject.GetComponent<Image>().color = Color.red;
                quizManager.Wrong();
            }
        }
        else if(gameObject.tag == "Play")
        {
            quizManager.Play();
        }
    }
    // Start is called before the first frame update
}
