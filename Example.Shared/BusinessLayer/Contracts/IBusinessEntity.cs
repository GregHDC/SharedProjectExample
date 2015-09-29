using System;

namespace Example.Shared.BL.Contracts
{
	public interface IBusinessEntity
	{
		int ID { get; set; }

		DateTime LastUpdatedAt { get; set; }

	}
}

