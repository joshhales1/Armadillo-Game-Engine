using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
    static class Renderer
    {
        static List<SpriteRenderer> SpritesForRender = new List<SpriteRenderer>();
        public static Vector GameWindowDimensions = new Vector(20, 20);

        static char[,] OldBuffer = new char[0, 0];
        static char[,] CurrentBuffer = new char[0, 0];

        static bool SpecialRender = false;

        public static void Render()
        {
            OldBuffer = CurrentBuffer;
            CurrentBuffer = GenerateBuffer();

            if (!SpecialRender)
            {
                bool unmatched = false;
                //Check if lists are same
                if (OldBuffer.Length != CurrentBuffer.Length) unmatched = true;

                for (int x = 0; x < OldBuffer.GetLength(0); x++)
                    for (int y = 0; y < OldBuffer.GetLength(1); y++)
                    {
                        if (OldBuffer[x, y] != CurrentBuffer[x, y])
                        {
                            unmatched = true;
                            break;
                        }
                        if (unmatched) break;
                    }
                if (!unmatched) return;
            } else
            {
                SpecialRender = false;
            }

            Console.Clear();
            for (int x = 0; x < GameWindowDimensions.x; x++)
            {
                for (int y = 0; y < GameWindowDimensions.y; y++)
                    Console.Write(CurrentBuffer[x, y]);
                Console.Write("\n");
            }
            SpritesForRender.Clear();                
        }

        public static void RequestRender()
        {
            SpecialRender = true;
        }

        static char[,] GenerateBuffer()
        {
            char[,] grid = new char[(int)GameWindowDimensions.x, (int)GameWindowDimensions.y];

            foreach (SpriteRenderer sprite in SpritesForRender)
            {
                Vector offset = sprite.Owner.GetComponent<Transform>().Position;
                Vector dimensions = sprite.Dimensions;
                for (int x = 0; x < dimensions.x; x++)
                    for (int y = 0; y < dimensions.y; y++)
                    {
                        grid[(int)offset.x + x, (int)offset.y + y] = sprite.SpriteText[x, y];
                    }
                        
            }
            return grid;
        }

        public static void AddSprite(SpriteRenderer sprite) => SpritesForRender.Add(sprite);


    }
}
