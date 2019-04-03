using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace DataBelli.AcessoDados.Construtores
{
    public class MsSqlServerQueryBuilder<T> : IQueryBuilder<T>
    {
        public string BuildDelete(T instance)
        {
            throw new NotImplementedException();
        }

        public string BuildInsert(T instance, out Dictionary<string, object> parametros)
        {

            var table = typeof(T).GetCustomAttribute<TableAttribute>();

            if (table == null)
                throw new Exception("Nome da tabela não informado");

            parametros = new Dictionary<string, object>();

            var query = new StringBuilder("Insert Into ");
            var columns = new List<string>();
            var columnsParams = new List<string>();
            var columnsValues = new List<object>();

            query.Append(table.Name);
            

            foreach (var property in typeof(T).GetProperties())
            {
                var column = property.GetCustomAttribute<ColumnAttribute>();

                if (!property.IsPrimaryKey())
                {
                    columns.Add(column.Name);
                    columnsParams.Add("@" + column.Name);
                    columnsValues.Add(property.GetValue(instance));
                    parametros.Add(column.Name, property.GetValue(instance));
                }

            }

            query.Append("(");
            query.Append(string.Join(',', columns.ToArray()));
            query.Append(")Values(");
            //query.Append(string.Join(',', columnsParams.ToArray()));
            query.Append(string.Join(',', columns.Select(s => $"@{s}").ToArray()));
            query.Append(")");

            //return string.Join(',', columns.Select(s => $"@{s}").ToArray());

            return query.ToString();
        }

        public string BuildSelect(string where = null)
        {
            var table = typeof(T).GetCustomAttribute<TableAttribute>();            

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
