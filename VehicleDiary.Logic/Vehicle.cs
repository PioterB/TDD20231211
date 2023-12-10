using System;

namespace VehicleDiary.Logic
{
	public abstract class Vehicle : IEquatable<Vehicle>
	{
		protected Vehicle(string name)
		{
			Name = name;
		}

		public string Name { get; private set; }

		public bool Equals(Vehicle other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Name == other.Name;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Vehicle) obj);
		}

		public override int GetHashCode()
		{
			return (Name != null ? Name.GetHashCode() : 0);
		}
	}
}