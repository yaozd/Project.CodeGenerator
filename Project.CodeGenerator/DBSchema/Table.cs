using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Project.CodeGenerator.DBSchema
{
    public class Table
    {
        public Table(DataTable t)
        {
            this.TableName = t.TableName;
            this.PKs = this.GetPKList(t);
            this.Columns = this.GetColumnList(t);
            this.ColumnNames = this.SetColumnNames();
            this.ColumnTypeNames = this.SetColumnTypeNames();
        }

        public string TableName;
        public List<Column> PKs;
        public List<Column> Columns;
        public string ColumnNames;
        public string ColumnTypeNames;
        public List<Column> GetPKList(DataTable dt)
        {
            List<Column> list = new List<Column>();
            Column c = null;
            if (dt.PrimaryKey.Length > 0)
            {
                list = new List<Column>();
                foreach (DataColumn dc in dt.PrimaryKey)
                {
                    c = new Column(dc);
                    list.Add(c);
                }
            }
            return list;
        }

        private List<Column> GetColumnList(DataTable dt)
        {
            List<Column> list = new List<Column>();
            List<Column> listPk = new List<Column>();
            if (dt.PrimaryKey.Length > 0)
            {
                listPk.AddRange(dt.PrimaryKey.Select(column => new Column(column)));
            }
            Column c = null;
            foreach (DataColumn dc in dt.Columns)
            {
                c = new Column(dc);
                if (listPk.Where(m => m.ColumnName == c.ColumnName).FirstOrDefault() != null)
                {
                    c.IsPK = true;
                }
                list.Add(c);
            }
            return list;
        }

        private string SetColumnNames()
        {
            List<string> list = new List<string>();
            foreach (Column c in this.Columns)
            {
                list.Add(string.Format("{0}", c.LowerColumnName));
            }
            return string.Join(",", list.ToArray());
        }
        private string SetColumnTypeNames()
        {
            List<string> list = new List<string>();
            foreach (Column c in this.Columns)
            {
                list.Add(string.Format("{0} {1}", c.TypeName, c.LowerColumnName));
            }
            return string.Join(",", list.ToArray());
        }
    }
}