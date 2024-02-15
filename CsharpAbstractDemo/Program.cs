global using Raylib_cs;
global using System.Numerics;
using CsharpAbstractDemo;

Raylib.InitWindow(800, 600, "StratGame");
Raylib.SetTargetFPS(60);

Unit.Renderer = UnitRenderer.Get();

// Create buttons
List<IClickable> clickables = new();
List<Button> buttons = new();

buttons.Add(new Button(new(10, 400, 140, 30), "KLIKME", () => Console.WriteLine("hey!")));
buttons.Add(new Button(new(160, 400, 140, 30), "KLIKME2", () => Console.WriteLine("whoa!")));



// Create units
List<GameObject> gameObjects = new();
Unit.GameObjects = gameObjects;
Unit.ReverseButton = buttons[1];

Unit.Make(Vector2.Zero);
Unit.Make(new Vector2(64, 128));

GreenUnit green = GreenUnit.Make(new Vector2(0, 256));
gameObjects.Add(green);




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
      if (c is IHoverable)
      {
        if (( (IHoverable)c).PointIsInside(mousePosition))
        {
          c.Click();
        }
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