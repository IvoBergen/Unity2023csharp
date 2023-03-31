using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Player
{

    public GameObject obj;
    public Player(GameObject obj)
    {
        this.obj = obj;

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    bool CanMoveTo(Vector3 newPos, Tile[][] path)
    {
        for (int i = 0; i < path.Length; i++)
        {
            for (int i2 = 0; i2 < path[i].Length; i2++)
            {
                Tile t = path[i][i2] ;

                if (t.block)
                {
                    if(newPos.x == t.gameObject.transform.position.x && newPos.z == t.gameObject.transform.position.z)
                    {
                        return false;
                    }
                    
                }
                
                //1) Pak hier eerst de huidige Tile die in [i][i2] zit
                //2) check met een if of het de Tile een tower is
                //3) vergelijk de newPos met de transform.position van de Tile


                //4 als dat zo is return false!
            }
        }
        return true;
    }
    public void Move(Vector3 newPos, Tile[][] path)
    {
        Debug.Log("======move" +newPos);
        if (CanMoveTo(newPos, path))
        {
            Debug.Log("======CanMoveTo");
            obj.transform.position = newPos;
        }
    }
    public void DoMove(Tile[][] path)
    {
        Vector3 newPos = obj.transform.position;

        if (Input.GetKeyDown(KeyCode.W))
        {
            newPos.z += 2;
            Move(newPos, path);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            newPos.x -= 2;
            Move(newPos, path);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            newPos.z -= 2;
            Move(newPos, path);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            newPos.x += 2;
            Move(newPos, path);
        }
        //kijk hier welke of de speler up,down,left of right ingedrukt heeft
        
            //Tip: alle tiles zijn 2x bij 2z

        //als dat zo is dan verander je newPos (wat nu de huidige player position is)
            //bv:
            // als right down dan move naar rechts (tel +2 bij de x van newpos op)
            //roep de Move function aan, geef path door en geef newPos door

            //extra: roteer ook het GameObject van Player in de juiste richting
    }
}
