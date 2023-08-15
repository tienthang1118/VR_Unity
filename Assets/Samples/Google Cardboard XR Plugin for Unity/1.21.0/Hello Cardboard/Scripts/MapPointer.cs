using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointer : MonoBehaviour
{
    public GameObject player;
    private float spinSpeed = 1;
    [SerializeField] private float gazeDuration;
    private float gazeTime = 1.5f;
    private bool isGaze;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AutoSpin();
    }
    void AutoSpin()
    {
        transform.Rotate(0, spinSpeed, 0, Space.Self);
    }
    public void OnPointerEnter()
    {
        isGaze = true;
        transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
    }
    public void OnPointerExit()
    {
        isGaze = false;
        gazeDuration = 0;
        transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
    }
    public void OnPointerClick()
    {

    }
    void Move()
    {
        if (isGaze)
        {
            gazeDuration += Time.deltaTime;
        }
        if (gazeDuration >= gazeTime)
        {
            player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
    void OnMouseDown()
    {

    }
}
