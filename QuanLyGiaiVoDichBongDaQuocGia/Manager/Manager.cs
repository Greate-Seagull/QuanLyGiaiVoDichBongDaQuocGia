using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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

        public override string ToString()
        {
            return data.ToString();
        }
    }
    public class Manager<T>
    {
        HashSet<ManagedItem<T>> data = new HashSet<ManagedItem<T>>();

        //Insert to database
        public Manager()
        {}

        //Select from database
        public Manager(List<T> input)
        {
            data = new HashSet<ManagedItem<T>>();

            foreach(T item in input)
            {
                data.Add(new ManagedItem<T>(item, DataState.Unchanged));
            }
        }

        public int Count { get => data.Count; }

        public List<ManagedItem<T>> ProcessingData
        {
            get
            {
                List<ManagedItem<T>> items = new List<ManagedItem<T>>();

                foreach(var item in data)
                {
                    if(item.State == DataState.New ||
                       item.State == DataState.Modified ||
                       item.State == DataState.Deleting)
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
        }

        public List<ManagedItem<T>> ActiveData
        {
            get
            {
                List<ManagedItem<T>> items = new List<ManagedItem<T>>();

                foreach (var item in data)
                {
                    if (item.State <= DataState.Unchanged)
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
        }

        public List<ManagedItem<T>> UnusedData
        {
            get
            {
                List<ManagedItem<T>> items = new List<ManagedItem<T>>();

                foreach (var item in data)
                {
                    if (item.State != DataState.Using)
                    {
                        items.Add(item);
                    }
                }

                return items;
            }
        }

        public int CountActive => data.Count(item => item.State <= DataState.Unchanged);

        public bool Add(ManagedItem<T> newData)
        {
            return this.data.Add(newData);
        }

        public bool Delete(ManagedItem<T> newData)
        {
            if (data.Contains(newData) == false)
            {
                return false;
            }
            else if (newData.State == DataState.New || newData.State == DataState.Error)
            {
                data.Remove(newData);
            }
            else
            {
                newData.State = DataState.Deleting;
            }

            return true;
        }

        internal void CapNhatDuLieuLoi()
        {
            foreach (var item in data)
            {
                if (item.State == DataState.New)
                {
                    item.State = DataState.Error;
                }
            }
        }

        internal void CapNhatTrangThaiDuLieu()
        {
            foreach(var item in data)
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
    }
}
