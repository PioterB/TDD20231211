using System;
using System.ComponentModel.DataAnnotations;

namespace VehiclesDiary.Controllers
{
	public class VehicleCreationRequest
	{
		public VehicleCreationRequest()
		{
		}

		public string Make { get; set; }

		public string Model { get; set; }

		public DateTimeOffset Bought { get; set; }

		[Required]
		[StringLength(25, MinimumLength = 3)]
		public string Name { get; set; }
	}
}