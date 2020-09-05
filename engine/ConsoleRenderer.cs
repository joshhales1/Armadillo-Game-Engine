using System;
using System.Collections.Generic;

namespace ArmadilloEngine
{
    static class Renderer
    {
        static List<SpriteRenderer> SpritesForRender = new List<SpriteRenderer>();
        public static byte SingleChar = 1;
        public static byte DoubleChar = 2;

        public static byte RenderMode = DoubleChar;

        static char[,] OldBuffer = BufferTemplate();
        static char[,] CurrentBuffer = BufferTemplate();

        public static void Start()
        {
            Console.WriteLine(OldBuffer[10, 10]);
            Console.CursorVisible = false;
            SetGameWindowSize(new Vector(16, 16));
        }

        public static void Render()
        {
            OldBuffer = CurrentBuffer;
            CurrentBuffer = GenerateBuffer();

            for (int x = 0; x < OldBuffer.GetLength(0); x++)
                for (int y = 0; y < OldBuffer.GetLength(1); y++)
                {
                    if (OldBuffer[x, y] != CurrentBuffer[x, y])
                    {
                        Console.SetCursorPosition(x * RenderMode, y);
                        Console.Write("\b" + CurrentBuffer[x, y]);
                        if (RenderMode == DoubleChar)
                        {
                            Console.SetCursorPosition(x * 2 + 1, y);
                            Console.Write("\b" + CurrentBuffer[x, y]);
                        }
                    }
                }
        }

        static char[,] GenerateBuffer()
        {
            char[,] grid = BufferTemplate();

            foreach (SpriteRenderer sprite in SpritesForRender)
            {
                Vector offset = sprite.Owner.GetComponent<Transform>().Position;
                Vector dimensions = sprite.Dimensions;

                for (int x = 0; x < dimensions.x; x++)
                    for (int y = 0; y < dimensions.y; y++)
                    {
                        int xPos = (int)offset.x + x;
                        int yPos = (int)offset.y + y;
                        if (xPos > Console.BufferWidth / RenderMode - 1 || xPos < 0 || yPos > Console.BufferHeight - 1 || yPos < 0) continue;
                        grid[(int)offset.x + x, (int)offset.y + y] = sprite.SpriteText[x, y];
                    }                        
            }
            SpritesForRender.Clear();
            return grid;
        }

        public static void SetGameWindowSize(Vector a)
        {
            if (a.x < 16 || a.y < 16)
            {
                Debug.Log("Size must be larger than 15");
                return;
            }                

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize((int)a.x * RenderMode, (int)a.y);
            Console.SetWindowSize((int)a.x * RenderMode, (int)a.y);
        }

        static char[,] BufferTemplate() => new char[Console.BufferWidth / RenderMode, Console.BufferHeight];

        public static void AddSprite(SpriteRenderer sprite) => SpritesForRender.Add(sprite);

        
    }
}
