public class Coin
{
    Random rnd = new();
    public Rectangle coin;
    static Texture2D sprite = Raylib.LoadTexture("Coin.png");
    public bool isCollected = false;
    public static Vector2 position = Vector2.Zero;

    public Coin(List<Rectangle> grassBlocks) // Skapar ett nytt mynt på en slumpad position, eller positionen som slime ger när den dör.
    {
        if (position == Vector2.Zero) // Ifall slime inte gett en position, så skapar den ett mynt på en slumpad position.
        {
            do
            {
                coin = new Rectangle(rnd.Next(0, 1560), rnd.Next(0, 720), 40, 40); // Ge ny slumpat position
            } while (!IsOnGrassBlock(grassBlocks, new Vector2((int)coin.x, (int)coin.y))); // Om positionen den fått kolliderar med marken så kommer en ny position ges tills den inte gör det.
            if (IsOnGrassBlock(grassBlocks, new Vector2((int)coin.x, (int)coin.y))) // Om den inte kolliderar, öka positionen med 60 på y-axeln, annars spawnar den i marken på grass blocket.
            {
                coin.y -= 60;
            }
        }
        else // Om slime gett en position, så skapar den ett mynt på den positionen.
        {
            coin = new Rectangle(position.X, position.Y, 40, 40);
        }
    }

    public void Update() // Samma som hjärtat, kollar endast collision med spelaren och ändrar så att myntet har tagits upp.
    {
        if (Raylib.CheckCollisionPointRec(Player.playerPos, coin))
        {
            isCollected = true;
            Player.coins++;
        }
    }

    public void Draw() // Rita ut myntet.
    {
        Raylib.DrawTextureEx(sprite, new Vector2((int)coin.x, (int)coin.y), 0, 0.8f, Color.WHITE);
    }

    bool IsOnGrassBlock(List<Rectangle> grassBlocks, Vector2 position) // En bool-funktion som kollar om ett nytt mynt som ska spawna kolliderar med marken (typ). Om den gör det, skickas boolen tillbaka som true, annars false.
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