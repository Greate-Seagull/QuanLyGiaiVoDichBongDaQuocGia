using Mysqlx.Crud;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public class ManagedOwner<O>
    {
        HashSet<O> owners;
        int capacity;

        public ManagedOwner(int capacity = 1)
        {
            this.capacity = capacity;
            owners = new HashSet<O>(capacity);
        }

        public HashSet<O> Owners { get => owners; set => owners = value; }
        public int Capacity { get => capacity; set => capacity = value; }

        public bool Add(O owner)
        {
            if(owners.Count < capacity)
            {
                if (this.IsFull() == false)
                    return owners.Add(owner);
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        internal void Add(List<O> owners)
        {
            foreach(O owner in owners)
            {
                if (this.IsFull())
                    return;

                this.owners.Add(owner);
            }
        }

        internal bool IsFull()
        {
            if (owners.Count < this.Capacity)
                return false;
            return true;
        }

        internal bool Contain(O? owner)
        {
            return owners.Contains(owner);
        }

        internal bool Remove(O? owner)
        {
            return owners.Remove(owner);
        }
    }
    public class OwnerManager<D, O>
    {
        private Dictionary<D, ManagedOwner<O>> dict;

        public OwnerManager()
        {
            dict = new Dictionary<D, ManagedOwner<O>>();
        }

        public OwnerManager(List<D> danhSachDuLieu)
        {
            dict = new Dictionary<D, ManagedOwner<O>>();

            foreach (var duLieu in danhSachDuLieu)
            {
                this.AddData(duLieu);
            }
        }

        public Dictionary<D, ManagedOwner<O>> Dict { get => dict; set => dict = value; }

        public bool AddData(D data, int ownerCount = 1)
        {
            if (dict.ContainsKey(data))
            {
                return false;
            }
            else
            {
                dict.Add(data, new ManagedOwner<O>(ownerCount));
                return true;
            }
        }

        public bool AddOwner(D data, O owner)
        {
            if (dict.ContainsKey(data))
            {
                return dict[data].Add(owner);
            }            
            else
            {
                return false;
            }
        }

        public bool AddOwner(D data, List<O> owners)
        {
            if (dict.ContainsKey(data))
            {
                dict[data].Add(owners);
                return true;
            }
            else
            {                
                return false;
            }
        }

        public bool Remove(D data)
        {
            return dict.Remove(data);
        }

        public bool RemoveOwner(D data, O owner)
        {
            if(dict.ContainsKey(data))
            {                
                return dict[data].Remove(owner);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveOwner(O owner)
        {
            bool result = false;

            foreach(var key in dict.Keys)
            {
                result |= dict[key].Remove(owner);
            }

            return result;
        }

        public List<D> GetOwnableData(O owner)
        {
            List<D> ownableData = new List<D>();

            foreach(D key in dict.Keys)
            {
                if (dict[key].IsFull() == false ||
                    dict[key].Contain(owner))
                {
                    ownableData.Add(key);
                }
            }

            return ownableData;
        }
    }
}
