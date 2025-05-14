using Org.BouncyCastle.Asn1.Crmf;
using QuanLyGiaiVoDichBongDaQuocGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QuanLyGiaiVoDichBongDaQuocGia.FilterHelper
{
    public class FilterBuilder<T>
    {
        private Expression<Func<T, bool>> _filters;

        public static FilterBuilder<T> Where(Expression<Func<T, bool>> expression)
        {
            var builder = new FilterBuilder<T>();
            builder._filters = expression;
            return builder;
        }

        public FilterBuilder<T> And(Expression<Func<T, bool>> expression)
        {
            var param = Expression.Parameter(typeof(T));

            var body = Expression.AndAlso(Expression.Invoke(_filters, param), Expression.Invoke(expression, param));

            _filters = Expression.Lambda<Func<T, bool>>(body, param);

            return this;
        }

        public FilterBuilder<T> Or(Expression<Func<T, bool>> expression)
        {
            var param = Expression.Parameter(typeof(T));

            var body = Expression.OrElse(Expression.Invoke(_filters, param), Expression.Invoke(expression, param));

            _filters = Expression.Lambda<Func<T, bool>>(body, param);

            return this;
        }

        public Func<T, bool> ToFunc()
        {
            return _filters.Compile();
        }

        public SQLResult ToSQL()
        {
            var sqlConverter = new ToSqlConverter();
            return sqlConverter.Convert(_filters);
        }
    }
}
