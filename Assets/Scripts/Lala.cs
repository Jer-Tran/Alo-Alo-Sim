using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lala : MonoBehaviour
{
    public Tile[] tiles;
    public Player _player;
    public GameObject mechanics;
    public GameObject _arcaneBlight;
    public const int NONE = 0;
    public const int NORTH = 1;
    public const int EAST = 2;
    public const int SOUTH = 3;
    public const int WEST = 4;
    public int triggerType;
    public bool doTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ArcaneBlight();
        if (doTrigger)
        {
            if (triggerType == 0)
            {
                StartTrail();
            }
            else if (triggerType == 1)
            {
                ResetTiles();
            }
            doTrigger = false;
        }
    }

    private void ArcaneBlight()
    {
        // Generate a random rotation
        _arcaneBlight.GetComponent<Rotator>().DoRotation();
        // Summon an ArcaneBlight aoe

        // begin cast

        // Before cast end, rotate the aoe, then set it active
        Snapshot[] snapshots = _arcaneBlight.GetComponentsInChildren<Snapshot>();
        foreach (Snapshot ss in snapshots)
        {
            ss.DoSnapshot();
        }
    }

    private void Analysis()
    {
        // For each player,

        // Set their rotation, and weakspot
    }

    private void StartTrail()
    {
        //ResetTiles();
        // Then activate some of them

        // N E S W == 1 2 3 4
        var i = 0;
        var j = 0;
        var dir = EAST;

        GetTile(i,j).Activate();
        StartCoroutine(IgniteTile(i, j, dir));
    }

    private void ResetTiles()
    {
        foreach (Tile t in tiles)
        {
            t.Deactivate();
            t.ResetDirection();
        }
    }

    // Current arrangement, (0,0) is at top left, going L -> R
    private Tile GetTile(int i, int j)
    {
        return tiles[i * 5 + j];
    }

    private IEnumerator IgniteTile(int i, int j, int dir)
    {
        while (0 <= i && i < 5 && 0 <= j && j < 5)
        {
            var t = GetTile(i, j);
            GetTile(i, j).Activate();
            if (t.GetDirection() != 0)
            {
                dir = t.GetDirection();
            }

            switch (dir) // TODO: rest of directions
            {
                case NORTH:
                    i--; break;
                case EAST: 
                    j++; break;
                case SOUTH:
                    i++; break;
                case WEST:
                    j--; break;
            }

            yield return new WaitForSeconds(1);
        }
    }
}
