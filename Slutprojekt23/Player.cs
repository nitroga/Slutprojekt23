public class Player : Character
{
    Rectangle sourceRect;
    public static List<Projectile> projectiles = new();
    public static List<Heart> hearts = new();
    public static int coins = 0;
    double cooldown = 0.7;
    bool onCooldown = false;
    public int offset = 40;
    public float dir = 0;
    public static Vector2 playerPos;
    public static int playerHealth;
    public static Font font = Raylib.LoadFont("BACKTO1982.ttf");
    public bool active
    {
        get
        {
            return playerHealth > 0;
        }
        set { }
    }

    public Player() // Skapar spelaren.
    {
        playerHealth = 40;
        character = new Rectangle(0, 0, 40, 50);
        sprite = Raylib.LoadTexture("Player.png");
        sourceRect = new Rectangle(0, 0, sprite.width, sprite.height);
    }

    public override void Update() // Update funktionen, gör en override på character.Update() som den ärver ifrån.
    {
        base.Update(); // Kör Character.Update()
        PlayerMovement(); // Kör PlayerMovement()
        UpdateProjectile(); // Kör UpdateProjectile()
    }

    public void UpdateProjectile() // Update-funktion för projektiler, ja, jag gjorde det i Player.cs.
    {
        foreach (Projectile p in projectiles)
        {
            p.Shoot();
        }
        
        for (var i = 0; i < projectiles.Count; i++) // Kollar om projektilen är utanför skärmen eller om den träffar något. Om den gör det ska den försvinna.
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

    public void PlayerMovement() // Movement för spelaren.
    {
        playerPos = new Vector2(character.x + 20, character.y + 30);
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
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) || Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            if (!isJumping) isJumping = true;
        }
        if (Raylib.IsMouseButtonPressed(0) || Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            if (Raylib.GetTime() - cooldown >= 0.7) 
            {
                projectiles.Add(new Projectile(this));
                cooldown = Raylib.GetTime();
            }
        }
        if (isJumping)
        {
            character.y -= speed.Y;
        }

        if (character.y >= 720)
        {
            playerHealth = 0;
        }

        // Collision för player
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

        foreach (Rectangle r in Level.ground)
        {
            if (Raylib.CheckCollisionRecs(character, r))
            {
                if (character.y <= r.y + r.height)
                {
                    gravity += .3f;
                }
            }
        }
    }

    public void Draw() // Rita ut spelaren.
    {
        if (active) // Rita bara ut spelaren om den är aktiv, aka, lever.
        {
            Raylib.DrawText("HEALTH", 10, 10, 25, Color.BLACK);
            Raylib.DrawRectangle(10, 36, 210, 30, Color.BLACK);
            Raylib.DrawRectangle(15, 41, playerHealth * 5, 20, Color.GREEN);
            Raylib.DrawRectangle((int)character.x, (int)character.y - 12, 42, 9, Color.BLACK);
            Raylib.DrawRectangle((int)character.x, (int)character.y - 13, playerHealth, 8, Color.GREEN);
            Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
            Raylib.DrawText("Coins: " + coins, 10, 70, 25, Color.BLACK);
        }
        else // Om spelaren dör så ska det stå "Game Over" på skärmen.
        {
            Raylib.DrawTextEx(font, "Game Over", new Vector2(600, 250), 50, 1, Color.RED);
        }
        foreach (Projectile p in projectiles) // Rita ut projektilerna.
        {
            p.Draw();
        }
    }
}