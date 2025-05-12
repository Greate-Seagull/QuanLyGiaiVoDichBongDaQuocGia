using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QuanLyGiaiVoDichBongDaQuocGia.FilterHelper
{
    public class FilterCondition<T>
    {
        private readonly FilterBuilder<T> _builder;

        public FilterCondition(FilterBuilder<T> builder)
        {
            _builder = builder;
        }

        public T? Column { get; set; }
        public string Comparison { get; set; } = "=";
        public object? Value { get; set; }

        public FilterBuilder<T> EqualsTo(object value)
        {
            Comparison = "=";
            Value = value;
            return _builder;
        }

        public FilterBuilder<T> NotEqualsTo(object value)
        {
            Comparison = "!=";
            Value = value;
            return _builder;
        }

        public FilterBuilder<T> GreaterThan(object value)
        {
            Comparison = ">";
            Value = value;
            return _builder;
        }

        public FilterBuilder<T> LessThan(object value)
        {
            Comparison = "<";
            Value = value;
            return _builder;
        }

        public FilterBuilder<T> GreaterOrEqual(object value)
        {
            Comparison = ">=";
            Value = value;
            return _builder;
        }

        public FilterBuilder<T> LessOrEqual(object value)
        {
            Comparison = "<=";
            Value = value;
            return _builder;
        }

        public FilterBuilder<T> In(params object[] values)
        {
            Comparison = "IN";
            Value = values;
            return _builder;
        }

        public FilterBuilder<T> In(IEnumerable<object> values)
        {
            Comparison = "IN";
            Value = values;
            return _builder;
        }

        public string? FormatValue(object? value)
        {
            return value switch
            {
                string s => $"'{s}'",
                DateTime dt => $"'{dt:yyyy-MM-dd HH:mm:ss}'",
                bool b => b ? "1" : "0",
                null => "NULL",
                _ => value.ToString()
            };
        }

        public override string ToString()
        {
            string formattedValue;
            switch(Comparison)
            {
                case "IN":
                    if (Value is IEnumerable<object> enumerable)
                        formattedValue = "(" + string.Join(", ", enumerable.Select(FormatValue)) + ")";
                    else
                        formattedValue = "(NULL)";
                    break;
                default:
                    formattedValue = FormatValue(Value);
                    break;
            }

            return $"{Column} {Comparison} {formattedValue}";
        }
    }

    public class FilterBuilder<T>
    {
        private readonly List<FilterCondition<T>> _filters = new();

        public static FilterCondition<T> Where(T column)
        {
            var builder = new FilterBuilder<T>();
            builder._filters.Add(new FilterCondition<T>(builder) { Column = column });
            return builder._filters.Last();
        }

        public FilterCondition<T> And(T column)
        {
            this._filters.Add(new FilterCondition<T>(this) { Column = column });
            return this._filters.Last();
        }

        public string Build()
        {
            return string.Join(" AND ", _filters);
        }
    }
}
