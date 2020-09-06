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
        sr.SetSprite("xxxxoxxxx");

        player.AddComponent<ObjectController>();

        Game.AddObject(player);
        Game.Start();
    }
}

