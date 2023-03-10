public class Level
{
    List<Texture2D> levelTextures = new List<Texture2D>() { Raylib.LoadTexture("Grass.png"), Raylib.LoadTexture("Ground.png") };
    int[,] level = new int[11, 20];
    List<Rectangle> ground = new List<Rectangle>();
    public static List<Rectangle> grass = new List<Rectangle>();


    public void LoadLevel()
    {
        level = new int[11, 20]{
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0},
            {1,1,1,1,1,1,0,0,0,0,0,1,2,2,2,2,1,1,1,1},
            {2,2,2,2,2,2,1,1,1,1,1,2,2,2,2,2,2,2,2,2},
        };

        for (int y = 0; y < level.GetLength(0); y++)
        {
            for (int x = 0; x < level.GetLength(1); x++)
            {
                if (level[y, x] == 1)
                {
                    grass.Add(new Rectangle(x * 40, y * 40, 40, 40));
                }
                if (level[y, x] == 2)
                {
                    ground.Add(new Rectangle(x * 40, y * 40, 40, 40));
                }
            }
        }
    }

    public void Draw()
    {
        foreach (Rectangle p in grass)
        {  
            Raylib.DrawTexture(levelTextures[0], (int)p.x, (int)p.y, Color.WHITE);
        }
        foreach (Rectangle p in ground)
        {  
            Raylib.DrawTexture(levelTextures[1], (int)p.x, (int)p.y, Color.WHITE);
        }
    }
}
