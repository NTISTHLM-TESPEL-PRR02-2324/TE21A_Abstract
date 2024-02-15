
namespace CsharpAbstractDemo;

public class GreenUnit : Unit, IClickable
{

  public void Click()
  {
    // _color = Color.Blue;
  }

  public bool PointIsInside(Vector2 point)
  {
    return Raylib.CheckCollisionPointRec(point, _rect);
  }

  public static GreenUnit Make(Vector2 startPosition)
  {
    GreenUnit u = new();
    u._unitRenderer = UnitRenderer.Get();
    u._rect = new(startPosition.X, startPosition.Y, 64, 64);
    return u;
  }
}
