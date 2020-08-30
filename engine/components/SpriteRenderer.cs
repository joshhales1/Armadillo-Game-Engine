using System;

namespace ArmadilloEngine
{
    class SpriteRenderer : IComponent
    {
        public GameObject Owner { get; set; }
        public Vector Dimensions { get; private set; }
        public char[,] SpriteText { get; private set; }
        public void Update()
        {
            Renderer.AddSprite(this);
        }

        public void Start() { }

        public void SetSprite(string spriteText)
        {
            char[,] sprite = StringToSpriteText(spriteText);
            SpriteText = sprite;
            Dimensions = new Vector(sprite.Length, sprite.Length) / (float)Math.Sqrt(sprite.Length);
        }

        public static char[,] StringToSpriteText(string str)
        {
            int size = (int)Math.Sqrt(str.Length);

            char[,] sprite = new char[size, size];
            int z = 0;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    sprite[x, y] = str[z];
                    z++;
                }
                    

            return sprite;
        }
    }


}
