public class Heart
{
    Random rnd = new();
    public Rectangle heart;
    public static Texture2D sprite = Raylib.LoadTexture("Heart.png");
    public bool isCollected = false;
    public static Vector2 position;

    public Heart() // Skapar ett ny hjärta på positon, som kommer från slime-positionen när den dött.
    {
        heart = new Rectangle(position.X, position.Y, 40, 40);
    }

    public void Update() // Update-funktionen, kollar endast collision med spelaren och ändrar så att hjärtat har tagits upp.
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

    public void Draw() // Ritar ut hjärtat.
    {
        Raylib.DrawTextureEx(sprite, new Vector2((int)heart.x, (int)heart.y), 0, 0.8f, Color.WHITE);
    }
}