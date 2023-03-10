global using Raylib_cs;
global using System.Numerics;

int ScrWidth = Raylib.GetScreenWidth();
int ScrHeight = Raylib.GetScreenHeight();
Raylib.InitWindow(800, 440, "Platformer");

Raylib.SetTargetFPS(60);

Player player = new Player();
Level level = new Level();
 level.LoadLevel();

while (!Raylib.WindowShouldClose()) {
    player.Update();

    Raylib.BeginDrawing();
    Raylib.DrawRectangleGradientV(0, 0, 800, 450, Color.SKYBLUE, Color.RAYWHITE);
    
    player.Draw();
    level.Draw();
   

    Raylib.EndDrawing();
}