using System;
using static Fun;

namespace FunApp
{
  public struct Birds
  {
    public static implicit operator Birds(int count) =>
      new Birds(count);

    public int Count { get; }

    public static Birds operator +(Birds lhs, Birds rhs) =>
      new Birds(lhs.Count + rhs.Count);

    public Birds(int count)
    {
      this.Count = count;
    }
  }

  public struct Pole
  {
    public Birds Left { get; }
    public Birds Right { get; }

    public Pole(Birds left, Birds right)
    {
      this.Left = left;
      this.Right = right;
    }    
  }

  public static class Api
  {
    public static Pole LandLeft(Birds birds, Pole pole) =>
      new Pole(pole.Left + birds, pole.Right);

    public static Pole LandRight(Birds birds, Pole pole) =>
      new Pole(pole.Left, pole.Right + birds);
  }

  internal class Program
  {
    static void Main(string[] args)
    {
      var result = Api.LandLeft(2, new Pole(0,0));
    }
  }
}
