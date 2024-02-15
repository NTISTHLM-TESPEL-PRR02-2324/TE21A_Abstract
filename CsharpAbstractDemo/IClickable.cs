namespace CsharpAbstractDemo;

public interface IClickable
{
  public void Click();
}

public interface IHoverable
{
  public bool PointIsInside(Vector2 point);
}