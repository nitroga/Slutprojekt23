public class Enemy : Character
{
    protected Rectangle sourceRect = new();
    protected double playerDmgCooldown = 1;
    protected double cooldown = 1;
    protected bool move = true;


    public bool active
    {
        get
        {
            return health > 0;
        }
        set { }
    }

    public virtual void Draw()
    {
        Raylib.DrawRectangle((int)character.x, (int)character.y + 6, 42, 9, Color.BLACK);
        Raylib.DrawRectangle((int)character.x, (int)character.y + 5, health, 8, Color.GREEN);
        Raylib.DrawTextureRec(sprite, sourceRect, new Vector2((int)character.x, (int)character.y), Color.WHITE);
    }
}
