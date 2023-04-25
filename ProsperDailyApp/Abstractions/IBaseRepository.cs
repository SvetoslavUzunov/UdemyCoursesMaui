using System.Linq.Expressions;

namespace ProsperDailyApp.Abstractions;

public interface IBaseRepository<T> : IDisposable where T : TableData, new()
{
   public void SaveItem(T item);

   public void SaveItemWithChildren(T item, bool recursive = false);

   public T GetItem(int id);

   public T GetItem(Expression<Func<T, bool>> predicate);

   public List<T> GetItems();

   public List<T> GetItems(Expression<Func<T, bool>> predicate);

   public List<T> GetItemsWithChildren();

   public void DeleteItem(T item);
}
