public class Heart
{
    Random rnd = new();
    public Rectangle heart;
    public static Texture2D sprite = Raylib.LoadTexture("Heart.png");
    public bool isCollected = false;
    public static Vector2 position;

    public Heart()
    {
        heart = new Rectangle(position.X, position.Y, 40, 40);
    }

    public void Update()
    {
        if (Raylib.CheckCollisionPointRec(Player.playerPos, heart))
        {
            if (Player.playerHealth < 40) 
            {
                isCollected = true;
                Player.playerHealth += 10;
            }
        }
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(sprite, new Vector2((int)heart.x, (int)heart.y), 0, 0.8f, Color.WHITE);
    }

    bool IsOnGrassBlock(List<Rectangle> grassBlocks, Vector2 position)
    {
        foreach (Rectangle grassBlock in Level.grass)
        {
            if (Raylib.CheckCollisionPointRec(position, grassBlock))
            {
                return true;
            }
        }
        return false;
    }
}