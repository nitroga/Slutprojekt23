public class Player : Character
{
    public Player()
    {
        character = new Rectangle(0, 0, 40, 60);
    }

    public override void Update()
    {
        base.Update();
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        gravity += 0.15f;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            character.x -= speed.X;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            character.x += speed.X;
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

        character.y += gravity;
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(character, Color.BLACK);
    }
}
