using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public Player _player;
    public bool _active;

    // Start is called before the first frame update
    void Start()
    {
        _player = (Player)FindFirstObjectByType(typeof(Player));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_active)
        {
            _player.DetonateMine();
            Deactivate();
        }
    }
}
