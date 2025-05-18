namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public class ManagedOwner<O>
    {
        HashSet<O> owners;
        HashSet<O> blacklist;
        int capacity;

        public ManagedOwner(int capacity = 1)
        {
            this.capacity = capacity;
            owners = new HashSet<O>(capacity);
            blacklist = new HashSet<O>();
        }

        public HashSet<O> Owners { get => owners; set => owners = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public HashSet<O> Blacklist { get => blacklist; set => blacklist = value; }

        public bool AddOwner(O owner)
        {
            if(owners.Count < capacity)
            {
                if (this.IsOwnerFull() == false)
                    return owners.Add(owner);
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        internal void AddOwner(List<O> owners)
        {
            foreach(O owner in owners)
            {
                if (this.IsOwnerFull())
                    return;

                this.owners.Add(owner);
            }
        }

        internal bool IsOwnerFull()
        {
            if (owners.Count < this.Capacity)
                return false;
            return true;
        }

        internal bool ContainOwner(O? owner)
        {
            return owners.Contains(owner);
        }

        internal bool RemoveOwner(O? owner)
        {
            return owners.Remove(owner);
        }

        internal bool AddToBlackList(O? owner)
        {
            return Blacklist.Add(owner);
        }

        internal bool RemoveFromBlacklist(O? owner)
        {
            return Blacklist.Remove(owner);
        }

        internal bool ContainBlaclist(O? owner)
        {
            return Blacklist.Contains(owner);
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

        public OwnerManager(DataManager<D> danhSachDuLieu)
        {
            dict = new Dictionary<D, ManagedOwner<O>>();

            foreach(var duLieu in danhSachDuLieu.ActiveData)
            {
                this.AddData(duLieu.Data);
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
                return dict[data].AddOwner(owner);
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
                dict[data].AddOwner(owners);
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
                return dict[data].RemoveOwner(owner);
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
                result |= dict[key].RemoveOwner(owner);
            }

            return result;
        }

        public List<D> GetOwnableData(O owner)
        {
            List<D> ownableData = new List<D>();

            foreach(D key in dict.Keys)
            {
                if (dict[key].ContainBlaclist(owner))
                    continue;

                if (dict[key].IsOwnerFull() == false ||
                    dict[key].ContainOwner(owner))
                {
                    ownableData.Add(key);
                }
            }

            return ownableData;
        }

        public HashSet<O> GetOwners(D data)
        {
            return dict[data].Owners;
        }

        public bool AddToBlacklist(D data, O owner)
        {
            if(dict.ContainsKey(data))
            {
                return dict[data].AddToBlackList(owner);
            }
            else
            {
                return false;
            }
        }

        public bool AddToBlacklist(List<D> datas, O owner)
        {
            bool result = false;
            foreach(var data in datas)
            {
                if (dict.ContainsKey(data))
                {
                    result |= dict[data].AddToBlackList(owner);
                }
            }
            return result;
        }

        public bool RemoveFromBlacklist(D data, O owner)
        {
            if (dict.ContainsKey(data))
            {
                return dict[data].RemoveFromBlacklist(owner);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveFromBlackList(List<D> datas, O owner)
        {
            bool result = false;
            foreach (var data in datas)
            {
                if (dict.ContainsKey(data))
                {
                    result |= dict[data].RemoveFromBlacklist(owner);
                }
            }
            return result;
        }

        public bool RemoveFromBlacklist(O owner)
        {
            bool result = false;
            foreach(var key in dict.Keys)
            {
                result |= dict[key].RemoveFromBlacklist(owner);
            }
            return result;
        }
    }
}
