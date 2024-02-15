
namespace CsharpAbstractDemo;

public class GreenUnit : Unit, IClickable
{
  public GreenUnit(Vector2 startPosition) : base(startPosition)
  {
    // _color = Color.Green;
  }

  public void Click()
  {
    // _color = Color.Blue;
  }

  public bool PointIsInside(Vector2 point)
  {
    return Raylib.CheckCollisionPointRec(point, _rect);
  }
}
