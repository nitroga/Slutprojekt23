public class Projectile
{
    private static Texture2D fireball = Raylib.LoadTexture("Fireball.png");
    public Vector2 projectilePos;
    float rotation;
    int dir = 1; 

    public Projectile(Player p){
        projectilePos = new Vector2(p.character.x + p.offset, p.character.y + 20);
        if (p.dir == -1)
        {
            rotation = 180;
            dir = -1;
            projectilePos.Y = p.character.y + 40;
        }
        else {
            rotation = 0;
            dir = 1;
        }
    }

    public void Shoot(Player p)
    {
        projectilePos.X += 4.5f * dir;
    }

    public void Draw(Player p) 
    {
        Raylib.DrawTextureEx(fireball, projectilePos, rotation, 1, Color.WHITE);
    }
}