using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public enum OperationType
    {
        Upsert = 0,
        Delete = 1
    }
    public class ManagedItem<T>
    {
        T data;
        OperationType operation;

        public ManagedItem(T data, OperationType operation = OperationType.Upsert)
        {
            this.Data = data;
            this.Operation = operation;
        }

        public T Data { get => data; set => data = value; }
        public OperationType Operation { get => operation; set => operation = value; }
    }
    public class Manager<T>
    {
        Dictionary<string, ManagedItem<T>> items = new Dictionary<string, ManagedItem<T>>();

        public Dictionary<string, ManagedItem<T>> Items { get => items; set => items = value; }
        public int Count { get => items.Count; }        
        public List<T> ViewData 
        {
            get
            {
                List<T> viewData = new List<T>();
                foreach (ManagedItem<T> value in items.Values)
                {
                    if (value.Operation == OperationType.Upsert)
                        viewData.Add(value.Data);
                }
                return viewData;
            }
        }        

        public void Add(string key, T value)
        {
            this.Items.Add(key, new ManagedItem<T>(value));
        }

        public void Delete(string key)
        {
            this.Items[key].Operation = OperationType.Delete;
        }
    }
}
