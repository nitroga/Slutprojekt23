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

    public Slime() // Skapar slime
    {
        health = 40;
        character = new Rectangle(rnd.Next(60, 1500), 200, 40, 40);
        sprite = Raylib.LoadTexture("Slime.png");
        sourceRect = new Rectangle(0, 0, -sprite.width, sprite.height);
    }

    public override void Update() // Update funktionen, gör en override på character.Update() som den ärver ifrån.
    {
        base.Update(); // Kör Character.Update()
        SlimeMovement(); // Kör SlimeMovement()
    }

    public void SlimeMovement() // Movement för slime.
    {
        if (move == true) // Om move är true, så ska slime gå åt höger.
        {
            sourceRect.width = -sprite.width;
            character.x += 1.5f;
            if (character.x >= 1560) // Om slimen är längst på höger sida, så ska den gå åt vänster.
            {
                move = false;
            }
        }

        else // Om move är false, så ska den gå åt vänster.
        {
            sourceRect.width = sprite.width;
            character.x -= 1.5f;
            if (character.x <= 0) // Om slime är längst på vänster sida, så ska den gå åt höger.
            {
                move = true;
            }
        }

        // Collision för slime
        foreach (Rectangle r in Level.grass) // Slimen ska inte kunna åka igenom gräset.
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

        foreach (Projectile p in Player.projectiles) // Om slimen träffas av en projectile, så ska den ta skada.
        {
            if (Raylib.CheckCollisionPointRec(p.projectilePos, character) && Raylib.GetTime() - cooldown >= 0.7)
            {
                health -= 10;
                cooldown = Raylib.GetTime();
                Player.projectiles.Remove(p);
                break;
            }
        }

        foreach (Rectangle w in Level.water) // Om slimen rör vatten, så ska den vända om och gå åt andra hållet.
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

        if (Raylib.CheckCollisionPointRec(Player.playerPos, character) && Raylib.GetTime() - playerDmgCooldown >= 0.5) // Om den kolliderar med spelaren, så ska spelaren ta skada.
        {
            Player.playerHealth -= 10;
            playerDmgCooldown = Raylib.GetTime();
        }
    }

    public void Draw() // Rita ut slime.
    {
        Raylib.DrawRectangle((int)character.x, (int)character.y + 6, 42, 9, Color.BLACK);
        Raylib.DrawRectangle((int)character.x, (int)character.y + 5, health, 8, Color.GREEN);
        Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
    }
}
