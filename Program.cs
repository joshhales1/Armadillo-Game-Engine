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
        player.AddComponent<Test>();

        GameObject wall = new GameObject();
        Transform walltr = wall.AddComponent<Transform>();
        walltr.Position = new Vector(2, 2);

        SpriteRenderer wallsr = wall.AddComponent<SpriteRenderer>();
        string spriteStringw = "xxxxoxxxx";
        wallsr.SetSprite(SpriteRenderer.StringToSpriteText(spriteStringw, 3, 3));
        wall.AddComponent<BoxCollider>().Dimensions = new Vector(3,3);
        player.AddComponent<BoxCollider>();     
        



        Game.AddObject(player);
        Game.AddObject(wall);





        Game.Start(30, 30); // Code past this point will not execute.
    }
}


