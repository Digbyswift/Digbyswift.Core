using System;

namespace Digbyswift.Core.Models
{
	public static class SystemTime
	{
        public static Func<DateTime> UtcNow = () => DateTime.UtcNow;

        public static Func<DateTime> UtcToday = () => DateTime.UtcNow.Date;

        public static Func<DateTime> LocalNow = () => DateTime.Now;

        public static Func<DateTime> LocalToday = () => DateTime.Now.Date;

		public static void Freeze(DateTime? frozenDate = null)
		{
			var workingDate = frozenDate ?? new DateTime(UtcNow().Ticks, DateTimeKind.Utc);

            UtcNow = () => workingDate;
            UtcToday = () => workingDate.Date;
            
            LocalNow = () => workingDate.ToLocalTime();
            LocalToday = () => workingDate.ToLocalTime().Date;
		}

	}
}