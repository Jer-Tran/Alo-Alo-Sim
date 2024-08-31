using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _playerSpeed;
    public int _weakSpot;
    public bool _forcedMarch;
    public int _mineStacks;

    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 Movement = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        //transform.position += Movement * speed * Time.deltaTime;
        Vector3 Movement = transform.TransformDirection(new Vector3(0, 0, Input.GetAxis("Vertical")));
        transform.position += Movement * _playerSpeed * Time.deltaTime;

        float playerRot = Input.GetAxis("Horizontal") * turnSpeed;
        transform.Rotate(0, playerRot, 0);
    }

    public void GetHit()
    {
        Debug.Log("player got hit");
    }

    public void ForcedMarch()
    {

    }

    public void DetonateMine()
    {
        if (_mineStacks == 0)
        {
            GetHit();
        }
        else
        {
            _mineStacks--;
        }
    }

    public void CheckMines()
    {
        if (_mineStacks != 0)
        {
            GetHit();
        }
    }
}
