public class Settings
{
    Texture2D settingsImg = Raylib.LoadTexture("Settings.png");
    public bool enabled = false;
    public bool exit = false;
    Rectangle settingsWindow = new Rectangle(Raylib.GetScreenWidth() / 2 - 100, Raylib.GetScreenHeight() / 2 - 300, 200, 350);
    Rectangle quitGame = new Rectangle(Raylib.GetScreenWidth() / 2 - 90, Raylib.GetScreenHeight() / 2 - 20, 180, 60);
    Rectangle fullscreen = new Rectangle(Raylib.GetScreenWidth() / 2 - 90, Raylib.GetScreenHeight() / 2 - 90, 180, 60);
    public void Update() 
    {
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE) || Raylib.IsWindowHidden())
        {
            enabled = !enabled;
        }
        if (enabled)
        {
            Raylib.ShowCursor();
            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), quitGame))
                {
                    exit = true;
                    Raylib.CloseWindow();
                }
            }
        }
        else 
        {
            Raylib.HideCursor();
        }
    }

    public void Draw() 
    {
        Raylib.DrawTexture(settingsImg, Raylib.GetScreenWidth() - settingsImg.width - 5, 5, Color.WHITE);
        if (enabled)
        {
            Raylib.DrawRectangleRounded(settingsWindow, 0.2f, 10, Color.BLACK);
            Raylib.DrawRectangleRounded(quitGame, 0.2f, 10, Color.WHITE);
            //Raylib.DrawRectangleRounded(fullscreen, 0.2f, 10, Color.WHITE);
            Raylib.DrawText("Quit Game", Raylib.GetScreenWidth() / 2 - 72, Raylib.GetScreenHeight() / 2, 30, Color.BLACK);
            //Raylib.DrawText("Fullscreen", Raylib.GetScreenWidth() / 2 - 78, Raylib.GetScreenHeight() / 2 - 70, 30, Color.BLACK);
            Raylib.DrawRectangleRoundedLines(settingsWindow, 0.2f, 10, 4, Color.WHITE);
        }
    }
}
