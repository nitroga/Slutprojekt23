public class Player : Character
{
    Rectangle sourceRect;

    public Player()
    {
        character = new Rectangle(0, 0, 40, 50);
        sprite = Raylib.LoadTexture("Player.png");
        sourceRect = new Rectangle(0, 0, sprite.width, sprite.height);
    }

    public override void Update()
    {
        base.Update();
        PlayerMovement();
    }

    public void PlayerMovement()
    {

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            character.x -= speed.X;
            sourceRect.width = -sprite.width;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            character.x += speed.X;
            sourceRect.width = sprite.width;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && !isJumping)
        {
            isJumping = true;
        }
        if (isJumping)
        {
            character.y -= speed.Y;
        }

        foreach (Rectangle r in Level.grass)
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

    public void Draw()
    {
        Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
    }
}