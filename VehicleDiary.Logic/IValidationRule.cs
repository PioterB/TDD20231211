namespace VehiclesDiary.Logic
{
    public interface IValidationRule<T>
    {
        bool NotBroken(T input);
    }
}