using System;
using System.Collections.Generic;

public static partial class Fun
{
  public static Maybe<T> None<T>() =>
    Maybe<T>.None;

  public static Maybe<T> Some<T>(T value) =>
    new Maybe<T>(value);

  public static Maybe<T> ToMaybe<T>(this T value) =>
    new Maybe<T>(value);

  public static Maybe<R> Apply<T1, T2, R>(this Maybe<T1> v1, Maybe<T2> v2, Func<T1, T2, R> map)
  {
    return v1
      .Then(a1 => v2
      .Then(a2 => map(a1, a2)));      
  }

  public static Maybe<TValue> ValueOf<TKey, TValue>(this Dictionary<TKey, TValue> src, TKey key) =>
    src.TryGetValue(key, out TValue value) ? value : None<TValue>();

  public struct Maybe<T>
  {
    private bool IsSome { get; }
    private T Value { get; }

    public static readonly Maybe<T> None = new Maybe<T>();

    public static implicit operator Maybe<T>(T value) =>
      new Maybe<T>(value);

    public Maybe(T value)
    {
      this.IsSome = null != value;
      this.Value = value;
    }

    public R Match<R>(Func<R> none, Func<T, R> some) =>
      IsSome ? some(Value) : none();

    public Maybe<R> Then<R>(Func<T, R> map) =>
      IsSome ? new Maybe<R>(map(Value)) : Maybe<R>.None;

    public Maybe<R> Then<R>(Func<T, Maybe<R>> bind) =>
      IsSome ? bind(Value) : Maybe<R>.None;

    public override string ToString() =>
      IsSome ? $"{Value}" : "None";
  }
}
