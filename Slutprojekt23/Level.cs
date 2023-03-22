public class Level
{
    Random rnd = new Random();
    bool loaded = false;
    static List<Texture2D> levelTextures = new List<Texture2D>() { Raylib.LoadTexture("Ground.png"), Raylib.LoadTexture("Grass.png"), Raylib.LoadTexture("SnowBlock.png") };
    static List<Texture2D> levelFlowers = new List<Texture2D>() { Raylib.LoadTexture("Pinkflower.png"), Raylib.LoadTexture("Yellowflower.png"), Raylib.LoadTexture("Blueflower.png") };
    public int[,] level = new int[11, 30];
    List<Rectangle> ground = new List<Rectangle>();
    public static List<Rectangle> grass = new List<Rectangle>();
    public static string type = "normal";
    public static int currentLevel = 0;
    List<int[,]> levels = new();

    public Level()
    {
        if (loaded == false)
        {
            addLevels();
            loaded = true;
        }
        ClearLevel();
        level = levels[currentLevel];
        updateLevel();
    }

    public void addLevels()
    {
        levels.Add(new int[11, 30]{
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2},
            {0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,1,1,2,2,2,2},
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
    }

    public void updateLevel() {
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
    }

    public void ClearLevel() 
    {
        ground.Clear();
        grass.Clear();
    }
}