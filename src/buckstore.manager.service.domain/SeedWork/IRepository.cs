namespace buckstore.manager.service.domain.SeedWork
{
	public interface IRepository<TEntity> where TEntity : IAggregateRoot
	{
		void Add(TEntity obj);
	}
}