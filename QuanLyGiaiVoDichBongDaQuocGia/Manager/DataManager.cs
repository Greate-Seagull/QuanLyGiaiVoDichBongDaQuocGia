using Mysqlx.Expr;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public enum DataState
    {
        New = 0,
        Modified = 1,
        Unchanged = 2,                
        Deleting = 3,
        Deleted = 4,
        Error = 5,
        Using = 6
    }
    public class ManagedItem<T>
    {
        T data;
        DataState state;

        public ManagedItem(T data, DataState state = DataState.New)
        {
            this.Data = data;
            this.State = state;
        }

        public T Data { get => data; set => data = value; }
        public DataState State { get => state; set => state = value; }

        public bool Modify()
        {
            if(State == DataState.Unchanged)
            {
                State = DataState.Modified;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return data.ToString();
        }
    }
    public class DataManager<T>
    {
        Dictionary<string, ManagedItem<T>> table = new Dictionary<string, ManagedItem<T>>();

        Func<T, string> keySelector;

        //Write to database
        public DataManager() { }
        //Read from database
        public DataManager(List<T> items, Func<T, string> keySelector)
        {
            this.keySelector = keySelector;

            foreach(var item in items)
            {
                string key = keySelector(item);
                this.Add(key, new ManagedItem<T>(item, DataState.Unchanged));
            }
        }

        public int Count { get => table.Count; }

        public List<T> UpsertData
        {
            get => Filter(default, dataState => dataState == DataState.New || dataState == DataState.Modified);            
        }

        public List<T> DeleteData
        {
            get => Filter(default, dataState => dataState == DataState.Deleting);
        }

        public List<ManagedItem<T>> ActiveData
        {
            get
            {
                List<ManagedItem<T>> items = new List<ManagedItem<T>>();

                foreach (var item in table.Values)
                {
                    if (item.State <= DataState.Unchanged)
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
        }

        public int CountActive => table.Values.Count(item => item.State <= DataState.Unchanged);

        public bool Add(string key, ManagedItem<T> newData)
        {
            if (table.ContainsKey(key))
            {
                return false;
            }
            else
            {
                table.Add(key, newData);
                return true;    
            }
        }

        public bool Add(string key, T newData)
        {
            if (table.ContainsKey(key))
            {
                return false;
            }
            else
            {
                table.Add(key, new ManagedItem<T>(newData));
                return true;
            }
        }

        public bool Update(string key, ManagedItem<T> newData)
        {
            if (table.ContainsKey(key))
            {
                table[key] = newData;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(string key, T newData)
        {
            if (table.ContainsKey(key))
            {
                table[key] = new ManagedItem<T>(newData);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddOrUpdate(string key, ManagedItem<T> newData)
        {
            if (table.ContainsKey(key))
            {
                table[key] = newData;
            }
            else
            {
                table.Add(key, newData);
            }
            return true;           
        }

        public bool Delete(string key)
        {
            if (table.ContainsKey(key) == false)
            {
                return false;
            }
            else if (table[key].State == DataState.New || table[key].State == DataState.Error)
            {
                table.Remove(key);
            }
            else
            {
                table[key].State = DataState.Deleting;
            }

            return true;
        }

        public T GetReadData(string key)
        {
            if(table.ContainsKey(key))
            {
                if (table[key].State == DataState.Unchanged)
                {
                    return table[key].Data;
                }
            }

            return default;
        }

        public List<T> GetReadData()
        {
            List<T> items = new List<T>();
            foreach(var key in table.Keys)
            {
                if (table[key].State == DataState.Unchanged)
                {
                    items.Add(table[key].Data);
                }
            }

            return items;
        }

        internal void UpdateDataState()
        {
            foreach(var item in table.Values)
            {
                if(item.State <= DataState.Modified) // New, Modified
                {
                    item.State = DataState.Unchanged;
                }
                else if(item.State == DataState.Deleting)
                {
                    item.State = DataState.Deleted;
                }
            }
        }

        public List<T> Filter(Func<T, bool>? dataPredicate = default, Func<DataState, bool>? statePredicate = default)
        {
            dataPredicate ??= d => true;
            statePredicate ??= s => s != DataState.Deleted;

            return table.Values
                        .Where(item => dataPredicate(item.Data) && statePredicate(item.State))
                        .Select(item => item.Data)
                        .ToList();
        }

        public void Merge(List<T> incomingItems, bool onDuplicateKeyUpdate = false)
        {
            foreach(var item in incomingItems)
            {
                string key = keySelector(item);
                var managedData = new ManagedItem<T>(item, DataState.Unchanged);
                if (onDuplicateKeyUpdate)
                    AddOrUpdate(key, managedData);
                else
                    Add(key, managedData);
            }
        }

        public void Merge(DataManager<T> incomingItems, bool onDuplicateKeyUpdate = false)
        {
            foreach(var item in incomingItems.table)
            {
                if (onDuplicateKeyUpdate)
                    AddOrUpdate(item.Key, item.Value);
                else
                    Add(item.Key, item.Value);
            }
        }
    }
}
