using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapshot : MonoBehaviour
{
    public Player _player;
    public bool _playerIn;
    public List<GameObject> _objects;

    // Start is called before the first frame update
    void Start()
    {
        _player = (Player) FindFirstObjectByType(typeof(Player));
        _playerIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoSnapshot(); // For testing
    }

    public void DoSnapshot()
    {
        // Play animation

        // For every object in collider, check if any players, if so trigger hit
        foreach (GameObject obj in _objects)
        {
            Player player = obj.GetComponent<Player>();
            if (player == null) { continue; }

            player.GetHit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _objects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _objects.Remove(other.gameObject);
    }
}
