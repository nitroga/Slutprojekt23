public class Heart : Item
{
    public Heart() // Skapar ett ny hjärta på positon, som kommer från slime-positionen när den dött.
    {
        sprite = Raylib.LoadTexture("Heart.png");
        item = new Rectangle(position.X, position.Y, 40, 40);
    }

    public void Update() // Update-funktionen, kollar endast collision med spelaren och ändrar så att hjärtat har tagits upp.
    {
        if (Raylib.CheckCollisionPointRec(Player.playerPos, item))
        {
            if (Player.playerHealth < 40) 
            {
                isCollected = true;
                Player.playerHealth += 10;
            }
        }
    }

    public override void Draw() // Ritar ut hjärtat.
    {
        base.Draw();
    }
}