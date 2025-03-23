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
    public class Manager<T>
    {
        List<T> data = new List<T>();
        List<OperationType> operation = new List<OperationType>();

        public List<T> Data { get => data; set => data = value; }
        public List<OperationType> Operation { get => operation; set => operation = value; }
        public int Count { get => data.Count; }
        public List<T> ViewData 
        {
            get
            {
                List<T> viewData = new List<T>();
                for (int i = 0; i < this.Count; i++)
                {
                    if (operation[i] == OperationType.Upsert)
                        viewData.Add(data[i]);
                }
                return viewData;
            }
        }

        public void Add(T dataInput)
        {
            this.data.Add(dataInput);
            this.operation.Add(OperationType.Upsert);
        }

        public void RemoveAt(int index)
        {
            this.Operation[index] = OperationType.Delete;
        }
    }
}
