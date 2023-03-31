using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class make oefening
public class Tile
{
    //maak variabelen:
    //?? hou hier je GameObject bij
    public GameObject gameObject;
    //?? hou hier bij of je beweging blokkeerd (een tower /muur bent) gebruik een bool
    public bool block;

    public Tile(GameObject gameObject, bool block)//pas deze constructor aan zodat GameObject & de bool meekomen
    {
        this.gameObject = gameObject;
        this.block = block;
    }
}
