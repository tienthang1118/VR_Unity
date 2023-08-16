using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointer : MonoBehaviour
{
    public GameObject player;
    private float spinSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AutoSpin();
    }
    void AutoSpin()
    {
        transform.Rotate(0, spinSpeed, 0, Space.Self);
    }
    public void OnPointerEnter()
    {
        transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
    }
    public void OnPointerExit()
    {
        transform.localScale -= new Vector3(0.03f, 0.03f, 0.03f);
    }
    public void IsTriggerPressed()
    {
        Move();
    }
    void Move()
    {
        player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
    void OnMouseDown()
    {

    }
}
