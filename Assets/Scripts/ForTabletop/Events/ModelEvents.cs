using System;
using UnityEngine;

public class ModelEvents
{
    public static event Action NewRoll;
    public static event Action FinishRoll;

    public static void RaiseNewRoll() => NewRoll?.Invoke();
    public static void RaiseFinishRoll() => FinishRoll?.Invoke();
}
