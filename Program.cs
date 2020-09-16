/* This is an example implementation of the game engine.
 * It shows basic usage and how to get started.
 * Check out the wiki for more indepth information.
*/

using System;
using ArmadilloEngine;

class Program 
{
    static void Main()
    {
        GameObject gameObject = new GameObject(); // Create a new game object.
        Transform transform = gameObject.AddComponent<Transform>(); // Give it a Transform component. 
        transform.Position = new Vector(5, 5); // Set its starting position.

        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>(); // Add a sprite renderer component.
        string spriteString = "xxxxoxxxx"; // The string used for the sprite. It is 3x3 so the string would be 9 letters long.

        /* 
         It would look like this:
         xxx
         xox
         xxx

         Note: The default renderer settings use double characters to make it look square. 
         Unless the render settings are set to 'single' it will look like this:
         xxxxxx
         xxooxx
         xxxxxx
         */ 

        spriteRenderer.SetSprite(SpriteRenderer.StringToSpriteText(spriteString, 3, 3)); // Set the sprite to the string

        gameObject.AddComponent<ObjectController>(); // Add another component. Provides basic control over an object.

        Game.AddObject(gameObject); // Add it to the game.

        Game.Start(30, 30); //Starts the game. Parameters 1 and 2 are the window size. The third is the render mode.
        
        // Code past this point will not execute. Use components from here on.
    }
}

