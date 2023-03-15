public class Slime : Character
{
    Rectangle sourceRect;
    bool move = true;

    public Slime()
    {
        health = 40;
        character = new Rectangle(0, 0, 40, 40);
        sprite = Raylib.LoadTexture("Slime.png");
        sourceRect = new Rectangle(0, 0, sprite.width, sprite.height);
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
            }
        }

        else
        {
            character.x -= 1.5f;
            if (character.x <= 0)
            {
                move = true;
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
                    isJumping = false;
                }
            }
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangle((int)character.x, (int)character.y + 6, 42, 9, Color.BLACK);
        Raylib.DrawRectangle((int)character.x, (int)character.y + 5, health, 8, Color.GREEN);
        Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
    }
}
