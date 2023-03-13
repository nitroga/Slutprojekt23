public class Level
{
    Random rnd = new Random();
    List<Texture2D> levelTextures = new List<Texture2D>() { Raylib.LoadTexture("Grass.png"), Raylib.LoadTexture("Ground.png") };
    List<Texture2D> levelFlowers = new List<Texture2D>() { Raylib.LoadTexture("Pinkflower.png"), Raylib.LoadTexture("Yellowflower.png"), Raylib.LoadTexture("Blueflower.png") };
    int[,] level = new int[11, 20];
    List<Rectangle> ground = new List<Rectangle>();
    List<Rectangle> yellowFlowers = new List<Rectangle>();
    List<Rectangle> blueFlowers = new  List<Rectangle>();
    List<Rectangle> pinkFlowers = new  List<Rectangle>();
    public static List<Rectangle> grass = new List<Rectangle>();


    public void LoadLevel()
    {
        level = new int[11, 30]{
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,3,0,0,3,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,3,0,0,3,0,0,0,0,3},
            {1,1,1,1,1,1,0,0,0,0,0,1,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1},
            {2,2,2,2,2,2,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
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
            Raylib.DrawTexture(levelTextures[0], (int)p.x, (int)p.y, Color.WHITE);
        }
        foreach (Rectangle p in ground)
        {  
            Raylib.DrawTexture(levelTextures[1], (int)p.x, (int)p.y, Color.WHITE);
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