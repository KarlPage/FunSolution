using System;

public static partial class Fun
{
  public static void FunSayHi(Action<string> textOutput) =>
    textOutput("Hello from the functional library!");
}
