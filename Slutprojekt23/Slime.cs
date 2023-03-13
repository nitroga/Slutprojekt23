public class Slime : Character
{
    Rectangle sourceRect;

    public Slime()
    {
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
