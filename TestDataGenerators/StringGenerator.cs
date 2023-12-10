using System;
using System.Linq;

namespace TestDataGenerators
{
	public class StringGenerator
	{
		private static readonly Random Rand = new Random((int)DateTime.Now.Ticks);
		private const int LettersAsciiOffset = 65;

		public static string Create(uint length = 1)
		{
			string result = string.Empty;
			for (int i = 0; i < length; i++)
			{
				result += (char) (Rand.Next(25) + LettersAsciiOffset);
			}

			return result;
		}
	}
}
