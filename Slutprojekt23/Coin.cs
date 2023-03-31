public class Coin
{
    Random rnd = new();
    public Rectangle coin;
    public Texture2D sprite = Raylib.LoadTexture("Coin.png");
    bool isCollected = false;

    public Coin(List<Rectangle> grassBlocks)
    {
        do
        {
            coin = new Rectangle(rnd.Next(0, 1560), rnd.Next(0, 500), 40, 40);
        } while (!IsOnGrassBlock(grassBlocks, new Vector2((int)coin.x, (int)coin.y)));
        if (IsOnGrassBlock(grassBlocks, new Vector2((int)coin.x, (int)coin.y)))
        {
            coin.y -= 60;
        }
    }

    public void Update()
    {
        if (Raylib.CheckCollisionPointRec(Player.playerPos, coin))
        {
            isCollected = true;
        }
    }

    public void Draw()
    {
        if (!isCollected) Raylib.DrawTextureEx(sprite, new Vector2((int)coin.x, (int)coin.y), 0, 0.8f, Color.WHITE);
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