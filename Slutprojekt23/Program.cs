global using Raylib_cs;
global using System.Numerics;

int ScrWidth = Raylib.GetScreenWidth();
int ScrHeight = Raylib.GetScreenHeight();
Raylib.InitWindow(1200, 440, "Platformer");

Raylib.SetTargetFPS(60);

Player player = new Player();
List<Slime> slimes = new() { new Slime(), new Slime(), new Slime() };
Level level = new Level();

while (!Raylib.WindowShouldClose())
{
    if (Raylib.IsKeyPressed(KeyboardKey.KEY_T))
    {
        if (player.character.x > 1100) 
        {
            Level.type = "snow";
            level = new Level();      
        }
    }
    player.Update();
    foreach (Slime s in slimes)
    {
        s.Update();
    }
    for (var i = 0; i < slimes.Count; i++)if (!slimes[i].active)slimes.RemoveAt(i);

    Raylib.BeginDrawing();
    Raylib.DrawRectangleGradientV(0, 0, 1200, 450, Color.SKYBLUE, Color.RAYWHITE);

    player.Draw();
    foreach (Slime s in slimes)
    {
        s.Draw();
    }
    level.Draw();



    Raylib.EndDrawing();
}