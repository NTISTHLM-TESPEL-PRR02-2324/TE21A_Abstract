global using Raylib_cs;
global using System.Numerics;
using CsharpAbstractDemo;

Raylib.InitWindow(800, 600, "StratGame");
Raylib.SetTargetFPS(60);

// Create units
List<GameObject> gameObjects = new();
gameObjects.Add(new Unit(Vector2.Zero));
gameObjects.Add(new Unit(new Vector2(64,128)));

GreenUnit green = new GreenUnit(new Vector2(0, 256));
gameObjects.Add(green);

// Create buttons
List<IClickable> clickables = new();
List<Button> buttons = new();

buttons.Add(new Button(new(10, 400, 140, 30), "KLIKME", () => Console.WriteLine("hey!")));
buttons.Add(new Button(new(160, 400, 140, 30), "KLIKME2", () => Console.WriteLine("whoa!")));

clickables.Add(buttons[0]);
clickables.Add(buttons[1]);
clickables.Add(green);


while (!Raylib.WindowShouldClose())
{
  // Get frame-wide variables
  float deltaTime = Raylib.GetFrameTime();
  Vector2 mousePosition = Raylib.GetMousePosition();

  // Update logic
  gameObjects.ForEach(g => g.Update(deltaTime));

  if (Raylib.IsMouseButtonPressed(0))
  {
    foreach (IClickable c in clickables)
    {
      if (c.PointIsInside(mousePosition))
      {
        c.Click();
      }
    }
  }

  // Draw
  Raylib.BeginDrawing();
  Raylib.ClearBackground(Color.White);

  gameObjects.ForEach(g => g.Draw());

  buttons.ForEach(b => b.Draw());

  Raylib.EndDrawing();
}