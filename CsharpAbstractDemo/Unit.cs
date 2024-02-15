namespace CsharpAbstractDemo;

public class Unit: GameObject
{
  protected Rectangle _rect;
  protected Vector2 _velocity;
  protected float _speed = 90f;

  protected IUnitRenderer _unitRenderer;

  public Unit(Vector2 startPosition, IUnitRenderer renderer)
  {
    _rect = new(startPosition.X, startPosition.Y, 64, 64);
    _velocity = Vector2.UnitX;
    _unitRenderer = renderer;
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
}
