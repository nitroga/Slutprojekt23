global using Raylib_cs;
global using System.Numerics;

int ScrWidth = Raylib.GetScreenWidth();
int ScrHeight = Raylib.GetScreenHeight();
Raylib.InitWindow(1200, 440, "Platformer");

Raylib.SetTargetFPS(60);

Player player = new Player();
Slime slime = new Slime();
Level level = new Level();
level.LoadLevel();

while (!Raylib.WindowShouldClose())
{
    player.Update();
    slime.Update();

    Raylib.BeginDrawing();
    Raylib.DrawRectangleGradientV(0, 0, 1200, 450, Color.SKYBLUE, Color.RAYWHITE);

    player.Draw();
    slime.Draw();
    level.Draw();
    


    Raylib.EndDrawing();
}