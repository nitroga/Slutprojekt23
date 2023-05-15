public class Character
{
    public Rectangle character;
    protected Vector2 speed = new Vector2(3, 5);
    protected float gravity;
    protected bool isJumping;
    protected Texture2D sprite;
    protected int health;
    protected Random rnd = new();

    public virtual void Update() // Update-funktionen för character, körs varje gång base.Update() körs för alla klasser som ärver från denna klass
    {
        gravity += 0.15f;
        character.y += gravity;
    }
}
