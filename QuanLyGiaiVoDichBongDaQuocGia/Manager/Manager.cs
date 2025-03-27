using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public enum OperationType
    {
        None = 0,
        Insert = 1,
        Update = 2,
        Delete = 3
    }
    public class ManagedItem<T>
    {
        T data;
        OperationType operation;

        public ManagedItem(T data, OperationType operation = OperationType.Insert)
        {
            this.Data = data;
            this.Operation = operation;
        }

        public T Data { get => data; set => data = value; }
        public OperationType Operation { get => operation; set => operation = value; }
    }
    public class Manager<T>
    {
        ConcurrentDictionary<string, ManagedItem<T>> items = new ConcurrentDictionary<string, ManagedItem<T>>();

        public ConcurrentDictionary<string, ManagedItem<T>> Items { get => items; set => items = value; }
        public int Count { get => items.Count; }
        public int CountActive
        {
            get
            {
                int count = 0;
                foreach (ManagedItem<T> item in items.Values)
                {
                    if (item.Operation != OperationType.Delete)
                    {
                        count++;
                    }
                }

                return count;
            }
        }       

        public bool Add(string key, ManagedItem<T> value)
        {      
           return this.Items.TryAdd(key, value);
        }

        public bool Delete(string key, bool hard = false)
        {
            if (this.Items.ContainsKey(key))
            {
                if (hard)
                {
                    this.Items.TryRemove(key, out _);
                }
                else
                {
                    this.Items[key].Operation = OperationType.Delete;
                }
                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
