using System;
using System.Threading.Tasks;

namespace buckstore.manager.service.domain.SeedWork
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}