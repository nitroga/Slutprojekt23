public class Slime : Character
{
    Rectangle sourceRect;
    bool move = true;
    public bool active
    {
        get
        {
            return health > 0;
        }
        set { }
    }
    double cooldown = 1;
    double playerDmgCooldown = 1;
    Random rnd = new Random();

    public Slime()
    {
        health = 40;
        character = new Rectangle(rnd.Next(60, 1500), 0, 40, 40);
        sprite = Raylib.LoadTexture("Slime.png");
        sourceRect = new Rectangle(0, 0, -sprite.width, sprite.height);
    }

    public override void Update()
    {
        base.Update();
        SlimeMovement();
    }

    public void SlimeMovement()
    {
        if (move == true)
        {
            sourceRect.width = -sprite.width;
            character.x += 1.5f;
            if (character.x >= 1560)
            {
                move = false;
            }
        }

        else
        {
            sourceRect.width = sprite.width;
            character.x -= 1.5f;
            if (character.x <= 0)
            {
                move = true;
            }
        }

        // Collision för slime
        foreach (Rectangle r in Level.grass)
        {
            if (Raylib.CheckCollisionRecs(character, r))
            {
                if (character.y + character.height >= r.y)
                {
                    character.y = r.y - character.height;
                    gravity = 0;
                }
            }
        }

        foreach (Projectile p in Player.projectiles)
        {
            if (Raylib.CheckCollisionPointRec(p.projectilePos, character) && Raylib.GetTime() - cooldown >= 0.7)
            {
                health -= 10;
                cooldown = Raylib.GetTime();
                Player.projectiles.Remove(p);
                break;
            }
        }

        foreach (Rectangle w in Level.water)
        {
            if ((int)character.y >= w.y - w.height)
            {
                if ((int)character.x == (int)w.x - w.width || (int)character.x == (int)w.x + w.width)
                {
                    move = !move;
                    break;
                }
            }
        }

        if (Raylib.CheckCollisionPointRec(Player.playerPos, character) && Raylib.GetTime() - playerDmgCooldown >= 0.7)
        {
            Player.playerHealth -= 10;
            playerDmgCooldown = Raylib.GetTime();
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)character.x, (int)character.y + 6, 42, 9, Color.BLACK);
        Raylib.DrawRectangle((int)character.x, (int)character.y + 5, health, 8, Color.GREEN);
        Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
    }
}
