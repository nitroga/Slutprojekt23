global using Raylib_cs;
global using System.Numerics;

int ScrWidth = Raylib.GetScreenWidth();
int ScrHeight = Raylib.GetScreenHeight();
Raylib.InitWindow(1600, 720, "Platformer");

Raylib.SetTargetFPS(60);

Player player = new();
List<Slime> slimes = new();
List<Coin> coins = new();
Level level = new();
double tpCooldown = 3;
Random rnd = new();

// Start-funktion(er)
enemySpawn();
coinSpawn();

while (!Raylib.WindowShouldClose())
{
    if (Raylib.GetTime() - tpCooldown <= 3)
    {
        if (player.character.x >= 1580)player.character.x = 1580;  
        else if (player.character.x <= -20)player.character.x = -20;  
    }
    
    else if (player.character.x >= 1580 && Raylib.GetTime() - tpCooldown >= 3) 
    {
        tpCooldown = Raylib.GetTime();
        Level.currentLevel++;
        level = new Level();    
        slimes.Clear(); 
        enemySpawn();
        player.character.x = -20; 
    }

    else if (player.character.x <= -20 && Raylib.GetTime() - tpCooldown >= 3) 
    {
        tpCooldown = Raylib.GetTime();
        if (Level.currentLevel != 0)
        {
            Level.currentLevel--;
            level = new Level();     
            slimes.Clear();
            enemySpawn();
            player.character.x = 1580; 
        }
    }

    player.Update();
    foreach (Slime s in slimes)
    {
        s.Update();
    }
    for (var i = 0; i < slimes.Count; i++)if (!slimes[i].active)slimes.RemoveAt(i);
    foreach (Coin c in coins)
    {
        c.Update();
    }

    Raylib.BeginDrawing();
    Raylib.DrawRectangleGradientV(0, 0, 1600, 720, Color.SKYBLUE, Color.RAYWHITE);

    level.Draw();
    foreach (Slime s in slimes)
    {
        s.Draw();
    }
    foreach (Coin c in coins)
    {
        c.Draw();
    }
    player.Draw();
    



    Raylib.EndDrawing();
}

void enemySpawn()
{
    for (var i = 0; i < rnd.Next(2,6); i++)
    {
        slimes.Add(new());
    }
}

void coinSpawn()
{
    for (var i = 0; i < rnd.Next(3,7); i++)
    {
        coins.Add(new(grassBlocks: Level.grass));
    }
}