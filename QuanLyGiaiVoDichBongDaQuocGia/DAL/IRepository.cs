using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface IRepository<T>
    {
        //Add methods
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        //Get methods
        T GetById(object id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, T>> selector, Expression<Func<T, bool>> filter);

        //Update methods
        void Update(T entity);

        //Delete methods
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        //Save changes
        void SaveChanges();
    }
}
