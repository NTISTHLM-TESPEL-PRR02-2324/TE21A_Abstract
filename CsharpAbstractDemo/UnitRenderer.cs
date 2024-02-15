namespace CsharpAbstractDemo;

public class UnitRenderer: IUnitRenderer
{
  private static UnitRenderer _instance;

  private UnitRenderer() {}

  public static UnitRenderer Get()
  {
    if (_instance == null) _instance = new();
    return _instance;
  }

  protected Color _color = Color.Red;

  public void Draw(Rectangle rect)
  {
    Raylib.DrawRectangleRec(rect, _color);
  }
}