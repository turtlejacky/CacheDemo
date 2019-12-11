using System;

namespace CacheDemo.Models
{
	public class CacheResultAttribute : Attribute
	{
		public CacheResultAttribute(int duration)
		{
			Duration = duration;
		}

		public int Duration { get; set; }
	}
}