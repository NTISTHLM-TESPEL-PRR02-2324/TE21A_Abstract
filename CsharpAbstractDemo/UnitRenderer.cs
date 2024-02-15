namespace CsharpAbstractDemo;

public class UnitRenderer: IUnitRenderer
{
  protected Color _color = Color.Red;

  public void Draw(Rectangle rect)
  {
    Raylib.DrawRectangleRec(rect, _color);
  }
}