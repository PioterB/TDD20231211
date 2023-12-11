﻿using System;

namespace VehicleDiary.Logic
{
	public abstract class Vehicle : IEquatable<Vehicle>
	{
		protected Vehicle(string name)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"{nameof(name)} is required");
			Name = name;
		}

		public string Name { get; private set; }

		public string Make { get; set; }
		
		public string Model { get; set; }

		public DateTime? Manufactured { get; set; }

		public bool Equals(Vehicle other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
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