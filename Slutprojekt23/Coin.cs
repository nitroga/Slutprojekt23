public class Coin : Item
{
    public Coin(List<Rectangle> grassBlocks) // Skapar ett nytt mynt på en slumpad position, eller positionen som slime ger när den dör.
    {
        sprite = Raylib.LoadTexture("Coin.png");
        if (position == Vector2.Zero) // Ifall slime inte gett en position, så skapar den ett mynt på en slumpad position.
        {
            do
            {
                item = new Rectangle(rnd.Next(0, 1560), rnd.Next(0, 720), 40, 40); // Ge ny slumpat position
            } while (!IsOnGrassBlock(grassBlocks, new Vector2((int)item.x, (int)item.y))); // Om positionen den fått kolliderar med marken så kommer en ny position ges tills den inte gör det.
            if (IsOnGrassBlock(grassBlocks, new Vector2((int)item.x, (int)item.y))) // Om den inte kolliderar, öka positionen med 60 på y-axeln, annars spawnar den i marken på grass blocket.
            {
                item.y -= 60;
            }
        }
        else // Om slime gett en position, så skapar den ett mynt på den positionen.
        {
            item = new Rectangle(position.X, position.Y, 40, 40);
        }
    }

    public void Update() // Samma som hjärtat, kollar endast collision med spelaren och ändrar så att myntet har tagits upp.
    {
        if (Raylib.CheckCollisionPointRec(Player.playerPos, item))
        {
            isCollected = true;
            Player.coins++;
        }
    }

     public override void Draw() // Ritar ut coin.
    {
        base.Draw();
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