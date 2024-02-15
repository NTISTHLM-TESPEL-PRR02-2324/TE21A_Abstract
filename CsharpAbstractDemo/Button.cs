namespace CsharpAbstractDemo;

public class Button : IClickable, IHoverable
{
  private Rectangle _rect;
  private string _label;
  private Action _action;

  // private List<IClickListener> clickListeners = new();

  public Action OnClick;

  // public void AddClickListener(IClickListener listener)
  // {
  //   clickListeners.Add(listener);
  // }

  public Button(Rectangle rectangle, string label, Action action)
  {
    _rect = rectangle;
    _label = label;
    _action = action;
  }

  public bool PointIsInside(Vector2 point)
  {
    return Raylib.CheckCollisionPointRec(point, _rect);
  }

  public void Click()
  {
    // clickListeners.ForEach(l => l.ClickAction());
    OnClick.Invoke();
    _action();
  }

  public void Draw()
  {
    Raylib.DrawRectangleRec(_rect, Color.Green);
    Raylib.DrawText(_label, (int)_rect.X + 5, (int)_rect.Y + 5, 20, Color.Black);
  }
}
