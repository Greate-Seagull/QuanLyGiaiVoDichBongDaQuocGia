using MySql.Data.MySqlClient;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Helper
{
    public class SQLResult
    {
        public string ParameterName { get; set; }
        public StringBuilder Clause { get; set; }
        public List<MySqlParameter> Parameters { get; set; }
    }

    /// <summary>
    /// Converts LINQ Expressions and object collections into SQL WHERE clauses or value lists with parameterization.
    /// </summary>
    public class ToSqlConverter: ExpressionVisitor
    {
        private static readonly Dictionary<ExpressionType, string> binaryConvertStore = new()
        {
            { ExpressionType.Equal, " = " },
            { ExpressionType.NotEqual, " != " },
            { ExpressionType.GreaterThan, " > " },
            { ExpressionType.GreaterThanOrEqual, " >= " },
            { ExpressionType.LessThan, " < " },
            { ExpressionType.LessThanOrEqual, " <= " },
            { ExpressionType.And, " AND " },
            { ExpressionType.Or, " OR " },            
        };

        private readonly string filterParamName = "@w";
        private readonly string insertParamName = "@i";

        private SQLResult result;

        public SQLResult Convert(Expression filters)
        {
            result = new() { ParameterName = filterParamName };
            Visit(filters);

            return result;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            result.Clause.Append("(");
            Visit(node.Left);
            result.Clause.Append(binaryConvertStore[node.NodeType]);
            Visit(node.Right);
            result.Clause.Append(")");

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            result.Clause.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            string paramName = $"{result.ParameterName}{result.Parameters.Count}";
            result.Clause.Append(paramName);
            result.Parameters.Add(new MySqlParameter(paramName, node.Value));
            return node;
        }

        public SQLResult Convert<T>(List<T> rows, List<Func<T, object>> columns)
        {
            result = new() { ParameterName = insertParamName };

            for(int i = 0; i < rows.Count; i++)
            {
                Convert<T>(rows[i], columns);

                if(i < rows.Count - 1)
                    result.Clause.Append(", ");
            }            

            return result;
        }

        private SQLResult Convert<T>(T row, List<Func<T, object>> columns)
        {
            var valuesBuilder = new List<string>();

            foreach (var col in columns)
            {
                string paramName = $"{result.ParameterName}{result.Parameters.Count}";
                valuesBuilder.Add(paramName);
                result.Parameters.Add(new MySqlParameter(paramName, col(row)));
            }

            result.Clause.Append("(");
            result.Clause.Append(string.Join(", ", valuesBuilder));
            result.Clause.Append(")");

            return result;
        }
    }
}
