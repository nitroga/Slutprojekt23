public class Item
{
    protected Random rnd = new();
    protected Rectangle item;
    protected Texture2D sprite;
    public bool isCollected = false;
    public static Vector2 position;


    public virtual void Draw(){
        Raylib.DrawTextureEx(sprite, new Vector2((int)item.x, (int)item.y), 0, 0.8f, Color.WHITE);
    }
}
