public class Level
{
    Random rnd = new Random();
    List<Texture2D> levelTextures = new List<Texture2D>() { Raylib.LoadTexture("Ground.png"), Raylib.LoadTexture("Grass.png"), Raylib.LoadTexture("SnowBlock.png") };
    List<Texture2D> levelFlowers = new List<Texture2D>() { Raylib.LoadTexture("Pinkflower.png"), Raylib.LoadTexture("Yellowflower.png"), Raylib.LoadTexture("Blueflower.png") };
    public static int[,] level = new int[11, 20];
    List<Rectangle> ground = new List<Rectangle>();
    List<Rectangle> yellowFlowers = new List<Rectangle>();
    List<Rectangle> blueFlowers = new List<Rectangle>();
    List<Rectangle> pinkFlowers = new List<Rectangle>();
    public static List<Rectangle> grass = new List<Rectangle>();
    public static List<int[,]> levels = new();
    public string type = "snow";
    public static int currentLevel = 0;

    public void LoadLevel()
    {
        levels.Add(new int[11, 30]{
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,3,0,0,0,0,0,0,3,0,1,1,1,2},
            {0,3,0,0,3,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,3,0,0,1,1,2,2,2,2},
            {1,1,1,1,1,1,0,0,0,0,0,1,2,2,2,2,2,2,1,1,1,1,1,1,2,2,2,2,2,2},
            {2,2,2,2,2,2,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
        });

        levels.Add(new int[11, 30]{
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,1,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,1,1,1,0,0,0,0,0},
            {1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,1,1,1,0,0},
            {2,2,2,1,1,1,1,1,0,0,0,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1},
            {2,2,2,2,2,2,2,2,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
        });

        updateLevel();
        level = levels[currentLevel];
    }

    public void updateLevel() {
        level = levels[currentLevel];
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
                if (level[y, x] == 3)
                {
                    level[y, x] = rnd.Next(3, 6);
                    if (level[y, x] == 3)
                    {
                        yellowFlowers.Add(new Rectangle(x * 40, y * 40, 40, 40));
                    }
                }
                if (level[y, x] == 4)
                {
                    blueFlowers.Add(new Rectangle(x * 40, y * 40, 40, 40));
                }
                if (level[y, x] == 5)
                {
                    pinkFlowers.Add(new Rectangle(x * 40, y * 40, 40, 40));
                }
            }
        }
    }

    public void Draw()
    {
        foreach (Rectangle p in grass)
        {
            if (type == "snow")
            {
                Raylib.DrawTexture(levelTextures[2], (int)p.x, (int)p.y, Color.WHITE);
            }
            else
            {
                Raylib.DrawTexture(levelTextures[1], (int)p.x, (int)p.y, Color.WHITE);
            }
        }
        foreach (Rectangle p in ground)
        {
            Raylib.DrawTexture(levelTextures[0], (int)p.x, (int)p.y, Color.WHITE);
        }
        foreach (Rectangle p in yellowFlowers)
        {
            Raylib.DrawTexture(levelFlowers[1], (int)p.x, (int)p.y, Color.WHITE);
        }
        foreach (Rectangle p in blueFlowers)
        {
            Raylib.DrawTexture(levelFlowers[2], (int)p.x, (int)p.y, Color.WHITE);
        }
        foreach (Rectangle p in pinkFlowers)
        {
            Raylib.DrawTexture(levelFlowers[0], (int)p.x, (int)p.y, Color.WHITE);
        }
    }
}