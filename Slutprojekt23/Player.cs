public class Player : Character
{
    Level level = new Level();
    Rectangle sourceRect;
    public static List<Projectile> projectiles = new();
    double cooldown = 1;
    bool onCooldown = false;
    public int offset = 40;
    public float dir = 0;

    public Player()
    {
        health = 40;
        character = new Rectangle(0, 0, 40, 50);
        sprite = Raylib.LoadTexture("Player.png");
        sourceRect = new Rectangle(0, 0, sprite.width, sprite.height);
    }

    public override void Update()
    {
        base.Update();
        PlayerMovement();
        UpdateProjectile();
    }
    public void UpdateProjectile()
    {
        foreach (Projectile p in projectiles)
        {
            p.Shoot(this);
        }
        for (var i = 0; i < projectiles.Count; i++)
        {
            if (projectiles[i].projectilePos.X < 0 || projectiles[i].projectilePos.X >= Raylib.GetScreenWidth())
            {
                projectiles.Remove(projectiles[i]);
            }
            else
            {
                for (var j = 0; j < Level.grass.Count; j++)
                {
                    if (Raylib.CheckCollisionPointRec(projectiles[i].projectilePos, Level.grass[j]))
                    {
                        projectiles.Remove(projectiles[i]);
                        break;
                    }
                }
            }
        }
    }

    public void PlayerMovement()
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            character.x -= speed.X;
            sourceRect.width = -sprite.width;
            offset = 0;
            dir = -1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            character.x += speed.X;
            sourceRect.width = sprite.width;
            offset = 40;
            dir = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && !isJumping)
        {
            isJumping = true;
        }
        if (Raylib.IsMouseButtonPressed(0) && Raylib.GetTime() - cooldown >= 0.7)
        {
            projectiles.Add(new Projectile(this));
            cooldown = Raylib.GetTime();
        }
        if (isJumping)
        {
            character.y -= speed.Y;
        }
        if (character.x >= 1160)
        {
            Level.level = Level.levels[1];
        }

        foreach (Rectangle r in Level.grass)
        {
            if (Raylib.CheckCollisionRecs(character, r))
            {
                if (character.y + character.height >= r.y)
                {
                    character.y = r.y - character.height;
                    gravity = 0;
                    isJumping = false;
                }
            }
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)character.x, (int)character.y - 12, 42, 9, Color.BLACK);
        Raylib.DrawRectangle((int)character.x, (int)character.y - 13, health, 8, Color.GREEN);
        Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
        foreach (Projectile p in projectiles)
        {
            p.Draw(this);
        }
    }
}