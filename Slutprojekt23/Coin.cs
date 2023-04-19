public class Coin
{
    Random rnd = new();
    public Rectangle coin;
    public static Texture2D sprite = Raylib.LoadTexture("Coin.png");
    public bool isCollected = false;
    public static Vector2 position = Vector2.Zero;

    public Coin(List<Rectangle> grassBlocks)
    {
        if (position == Vector2.Zero)
        {
            do
            {
                coin = new Rectangle(rnd.Next(0, 1560), rnd.Next(0, 720), 40, 40);
            } while (!IsOnGrassBlock(grassBlocks, new Vector2((int)coin.x, (int)coin.y)));
            if (IsOnGrassBlock(grassBlocks, new Vector2((int)coin.x, (int)coin.y)))
            {
                coin.y -= 60;
            }
        }
        else 
        {
            coin = new Rectangle(position.X, position.Y, 40, 40);
        }
    }

    public void Update()
    {
        if (Raylib.CheckCollisionPointRec(Player.playerPos, coin))
        {
            isCollected = true;
            Player.coins++;
        }
    }

    public void Draw()
    {
        Raylib.DrawTextureEx(sprite, new Vector2((int)coin.x, (int)coin.y), 0, 0.8f, Color.WHITE);
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