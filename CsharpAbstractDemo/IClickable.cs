namespace CsharpAbstractDemo;

public interface IClickable
{
  public bool PointIsInside(Vector2 point);
  public void Click();
}
