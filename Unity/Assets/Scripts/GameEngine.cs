using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameEngine : MonoBehaviour
{
    public GameObject pigModel;
    public GameObject tileModel;
    public GameObject towerModel;
    public GameObject doorModel;
    public GameObject devilModel;
    public Camera mainCamera;

    private Player player;
    private Tile[][] path;

    void Start()
    {
        int w = 10;
        int h = 10;
        path = new Tile[h][];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = new Tile[w];
            for (int i2 = 0; i2 < path[i].Length; i2++)
            {
                bool block = false;
                GameObject tileObj = tileModel;
                //test hier of het een buiten muur is ( bv i == 0 )
                if (i == 0) 
                {
                    tileObj = towerModel;
                    block = true;
                }
                if (i == 9)
                {
                    tileObj = towerModel;
                    block = true;
                }
                if (i2 ==0)
                {
                    tileObj = towerModel;
                    block = true;
                }
                if (i2 == 9)
                {
                    tileObj = towerModel;
                    block = true;
                }
                //tip: er zijn 4 muren aan de buitenkant

                //extra: gebruik random om meer torens neer te zetten
                //als dat zo is verander je de waarde van tileObj naar towerModel (gebruik een =)

                GameObject instance = MonoBehaviour.Instantiate(tileObj, new Vector3(i2 * 2, 0, i * 2), Quaternion.identity);
                path[i][i2] = new Tile(instance, block );//maak hier een Tile met new aan, gebruik je constructor uit stap 1
            }
        }

        GameObject playerSpawnPos = path[2][2].gameObject; //haal hier het GameObject op uit path(gebruik i=2, i2 = 2)
        Debug.Log(playerSpawnPos.transform.position);
        GameObject playerObj = Instantiate(pigModel, playerSpawnPos.transform.position, Quaternion.identity);
        player = new Player(playerObj); //maak hier een player instance aan


    }


    void Update()
    {
        player.DoMove(path);
        mainCamera.transform.position = player.obj.transform.position + new Vector3(0, 15, 0);
    }
}

