using System;

public class UIEvents
{
    public static event Action<uint, uint> DiceSpawn;
    public static event Action NewRound;
    public static event Action<uint> ChangeAmount;
    public static event Action<navType> TypeChanged;

    public static void RaiseDiceSpawn(uint power, uint amount) => DiceSpawn?.Invoke(power, amount);
    public static void RaiseNewRound() => NewRound?.Invoke();
    public static void RaiseChangeAmount(uint amount) => ChangeAmount?.Invoke(amount);
    public static void RaiseTypeChanged(navType navType) => TypeChanged?.Invoke(navType);

}
