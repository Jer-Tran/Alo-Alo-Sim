using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //public Player _player;
    public Vector3 _direction;
    public Transform _player;
    public float _dist;
    public Transform _cameraOffset;
    public float _playerSpeed;

    public float angleLock;
    public float turnSpeed;
    public float zoomSpeed;
    public float maxZoom;

    public float movementType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_player.position, transform.position);

        // Change distance
        _dist += -1 * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        _dist = Mathf.Clamp(_dist, 1, maxZoom);

        float x = Input.GetAxis("Mouse X") * turnSpeed;
        //// If holding LMB, rotate character
        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 rot = _player.rotation.eulerAngles;
        //    rot.y += x;
        //    _player.rotation = Quaternion.Euler(rot);
        //}
        //// If holding RMB, rotate camera
        //else 
        if (Input.GetMouseButton(1))
        {
            Vector3 rot = _cameraOffset.rotation.eulerAngles;
            float y = Input.GetAxis("Mouse Y") * turnSpeed;
            rot.x += -1 * y; // Values flipped cause of Quaternion stuff
            if (rot.x > 180) rot.x -= 360;
            rot.x = Mathf.Clamp(rot.x, -1 * angleLock, angleLock);
            rot.y += x;
            _cameraOffset.rotation = Quaternion.Euler(rot);

        }
        Vector3 direction = -1 * _cameraOffset.forward;
        Vector3 newPos = _player.position + direction * _dist;
        if (newPos.y > 0.1) { transform.position = _player.position + direction * _dist; } // Adjust later on, so it zooms in if this happens
        transform.LookAt(_player); // For future, to adjust the camera elevation, adjust the offset up/down

        //Vector3 Movement = _player.TransformDirection(new Vector3(0, 0, Input.GetAxis("Vertical")));
        //_player.position += Movement * _playerSpeed * Time.deltaTime;

        //float playerRot = Input.GetAxis("Horizontal") * turnSpeed;
        //_player.Rotate(0, playerRot, 0);
    }
}
