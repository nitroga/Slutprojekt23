public class Character
{
    protected Rectangle character;
    protected Vector2 speed = new Vector2(3, 5);
    protected float gravity;
    protected bool isJumping;
    protected Texture2D sprite;
    protected Vector2 dir;

    public virtual void Update()
    {
        gravity += 0.15f;
        character.y += gravity;
    }
}
