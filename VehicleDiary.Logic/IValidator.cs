﻿namespace VehiclesDiary.Logic
{
    public interface IValidator<T>
    {
        bool Validate(T item);
    }
}