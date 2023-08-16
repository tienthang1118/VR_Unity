using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Image img; 
    [SerializeField] private float totalTime;
    [SerializeField] private float timer;
    [SerializeField] private bool isFocus;

    // Update is called once per frame
    void Update()
    {
        if(isFocus)
        {
            timer += Time.deltaTime;
            img.fillAmount = timer/totalTime;
        }
        if(timer>totalTime)
        {
            OnPointerExit();
            GetComponent<Button>().onClick.Invoke();
        }
    }
    public void OnPointerEnter()
    {
        isFocus = true;        
    }
    public void OnPointerExit()
    {
        isFocus = false;
        timer = 0;
        img.fillAmount = 0;
    }
}
