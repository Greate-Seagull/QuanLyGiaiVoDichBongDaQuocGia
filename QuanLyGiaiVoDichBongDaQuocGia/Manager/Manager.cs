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
        Unmodified = 2,                
        Deleting = 3,
        Deleted = 4,
        Failed = 5
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
    }
    public class Manager<T>
    {
        HashSet<ManagedItem<T>> data;

        public Manager()
        {
            data = new HashSet<ManagedItem<T>>();
        }

        public int Count { get => data.Count; }
        public List<ManagedItem<T>> ProcessingData =>
            data.Where(item => item.State == DataState.New ||
                               item.State == DataState.Modified ||
                               item.State == DataState.Deleting).ToList();
        public List<ManagedItem<T>> ActiveData =>
            data.Where(item => item.State <= DataState.Unmodified).ToList();
        public int CountActive => data.Count(item => item.State <= DataState.Unmodified);

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
            else if (newData.State == DataState.New || newData.State == DataState.Failed)
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
                    item.State = DataState.Failed;
                }
            }
        }

        internal void CapNhatTrangThaiDuLieu()
        {
            foreach(var item in data)
            {
                if(item.State <= DataState.Modified) // New, Modified
                {
                    item.State = DataState.Unmodified;
                }
                else if(item.State == DataState.Deleting)
                {
                    item.State = DataState.Deleted;
                }
            }
        }
    }
}
