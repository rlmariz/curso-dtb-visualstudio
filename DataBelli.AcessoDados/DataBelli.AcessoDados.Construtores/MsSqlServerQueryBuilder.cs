using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DataBelli.AcessoDados.Construtores
{
    public class MsSqlServerQueryBuilder<T> : IQueryBuilder<T>
    {
        public string BuildDelete(T instance)
        {
            throw new NotImplementedException();
        }

        public string BuildInsert(T instance)
        {
            throw new NotImplementedException();
        }

        public string BuildSelect(string where = null)
        {
            var table = typeof(T).GetType().GetCustomAttribute<TableAttribute>();            

            if (table == null)
                throw new Exception("Nome da tabela não informado");

            var query = new StringBuilder("Select ");
            var columns = new List<string>();

            foreach (var property in typeof(T).GetProperties())
            {
                var column = property.GetCustomAttribute<ColumnAttribute>();

                columns.Add(column.Name);
            }

            query.Append(string.Join(',', columns.ToArray()));
            query.Append(" from ");
            query.Append(table.Name);

            if (!string.IsNullOrEmpty(where)) query.AppendLine(where);

            return query.ToString();
        }

        public string BuildUpdate(T instance)
        {
            throw new NotImplementedException();
        }
    }
}
