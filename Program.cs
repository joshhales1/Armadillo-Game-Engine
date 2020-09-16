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
        GameObject gameObject = new GameObject(); // Create a new GameObjects. By giving no arguments a Transform component is automatically added.
        Transform transform = gameObject.GetComponent<Transform>(); // Get the Transform component for us to work with.
        transform.Position = new Vector(5, 5); // Set its starting position.

        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>(); // Add a Sprite Renderer component.
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

        char[,] spriteArray = SpriteRenderer.StringToSpriteText(spriteString, 3, 3); // Turn the string into an array of characters.  
        spriteRenderer.SetSprite(spriteArray); // Set the sprite to the array.

        gameObject.AddComponent<ObjectController>(); // Add another component. Provides basic control over a GameObject with WASD.

        Game.AddObject(gameObject); // Add the GameObject to the game.

        Game.Start(30, 30); //Starts the game. Parameters 1 and 2 are the window size. The third is the render mode.
        
        // Code past this point will not execute. Use components from here on.
    }
}

