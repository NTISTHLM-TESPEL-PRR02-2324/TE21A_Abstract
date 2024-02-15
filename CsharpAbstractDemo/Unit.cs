using System.Net;

namespace CsharpAbstractDemo;

public class Unit: GameObject, IClickListener
{
  protected Rectangle _rect;
  protected Vector2 _velocity;
  protected float _speed = 90f;
  protected IUnitRenderer _unitRenderer;

  public Unit()
  {
    _velocity = Vector2.UnitX;
  }

  public override void Update(float deltaTime)
  {
    _rect.X += _velocity.X * _speed * deltaTime;

    if (_rect.X + _rect.Width > Raylib.GetScreenWidth() || _rect.X < 0)
    {
      _velocity = -_velocity;
    }
  }

  public override void Draw()
  {
    _unitRenderer.Draw(_rect);
  }

  public static IUnitRenderer Renderer { get; set; }
  public static List<GameObject> GameObjects { get; set; }
  public static Button ReverseButton { get; set; }

  public static Unit Make(Vector2 startPosition)
  {
    Unit u = new();
    u._unitRenderer = Renderer;
    u._rect = new(startPosition.X, startPosition.Y, 64, 64);
    GameObjects.Add(u);
    // ReverseButton.AddClickListener(u);
    
    ReverseButton.OnClick += u.ClickAction;

    return u;
  }

  public void ClickAction()
  {
    _velocity = -_velocity;
  }
}
