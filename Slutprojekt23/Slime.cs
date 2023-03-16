public class Slime : Character
{
    Rectangle sourceRect;
    bool move = true;
    bool active = true;
    double cooldown = 1;
    Random rnd = new Random();

    public Slime()
    {
        health = 40;
        character = new Rectangle(rnd.Next(50, 1100), 0, 40, 40);
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
            if (character.x >= 0)
            {
                character.x += 1.5f;
            }
            if (character.x >= 1160)
            {
                move = false;
                sourceRect.width = sprite.width;
            }
        }

        else
        {
            character.x -= 1.5f;
            if (character.x <= 0)
            {
                move = true;
                sourceRect.width = -sprite.width;
            }
        }

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
                if (health <= 0)
                {
                    active = false;
                }
            }
        }
    }

    public void Draw()
    {
        if (active)
        {
            Raylib.DrawRectangle((int)character.x, (int)character.y + 6, 42, 9, Color.BLACK);
            Raylib.DrawRectangle((int)character.x, (int)character.y + 5, health, 8, Color.GREEN);
            Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
        }
    }
}
