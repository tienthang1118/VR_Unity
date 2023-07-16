using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointer : MonoBehaviour
{
    public float m_spinSpeed;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AutoSpin();
    }
    void AutoSpin(){
        transform.Rotate(0, m_spinSpeed, 0, Space.Self);
    }
    public void OnPointerEnter()
    {
        transform.localScale += new Vector3(0.03f,0.03f,0.03f);
    }
    public void OnPointerExit()
    {
        transform.localScale -= new Vector3(0.03f,0.03f,0.03f);
    }
    public void OnPointerClick()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
}
