using System;
using ArmadilloEngine;

class Program 
{
    static void Main()
    {        

        GameObject player = new GameObject();
        Transform tr = player.AddComponent<Transform>();
        tr.Position = new Vector(5, 5);

        SpriteRenderer sr = player.AddComponent<SpriteRenderer>();
        string spriteString = "xxxxoxxxx";
        sr.SetSprite(SpriteRenderer.StringToSpriteText(spriteString, 3, 3));

        player.AddComponent<ObjectController>();
        
        Game.AddObject(player);
        Game.Start(30, 30);
        Debug.Log("hello");
        Debug.Log("helllllllllllllllllllllo");
        Debug.Log("oh hi");
        Debug.Log("helllllllllllllllllllllo");
        Debug.Log("oh hi");
        Debug.Log("helllllllllllllllllllllo");
        Debug.Log("oh hi");
        Debug.Log("helllllllllllllllllllllo");
        Debug.Log("oh hi");
        Debug.Log("o heyyyyyyyyyyyyyyyyyyyyyyyyy");

    }
}

