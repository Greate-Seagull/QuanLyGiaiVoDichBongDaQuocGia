using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public class ID
    {
        string _ID;
        bool isConfirm;

        public ID(string ID, bool isConfirm = false)
        {
            this._ID = ID;
            this.isConfirm = isConfirm;
        }

        public string GetID { get => _ID; set => _ID = value; }
        public bool IsConfirm { get => isConfirm; set => isConfirm = value; }

        public override string ToString()
        {
            return _ID;
        }

        public void Confirm()
        {
            isConfirm = true;
        }
    }
    public class IDManager
    {
        string maGoc;
        List<ID> maDaPhat;

        public IDManager(string iD)
        {
            maGoc = iD;
            maDaPhat = new List<ID>();
        }

        public ID GetNewID()
        {
            maDaPhat.Add(this.CreateID(maDaPhat.Count + 1));
            return maDaPhat[^1];
        }

        public ID GetCurrentID()
        {
            return maDaPhat[^1];
        }

        public void CancelID(ID iD)
        {
            if(iD.IsConfirm == false)
            {
                int index = maDaPhat.IndexOf(iD);
                for(int i = maDaPhat.Count - 1; i > index; i--)
                {
                    maDaPhat[i].GetID = maDaPhat[i - 1].GetID;
                }
                maDaPhat.RemoveAt(index);
            }
        }

        public ID CreateID(int v)
        {
            string kyTu = Regex.Replace(maGoc, "[^A-Za-z]", "");
            string so = Regex.Replace(maGoc, "[^0-9]", "");
            int soMoi = int.Parse(so) + v;
            int soLuongKyTuSo = maGoc.Length - kyTu.Length;
            string maMoi = kyTu + soMoi.ToString($"D{soLuongKyTuSo}");
            return new ID(maMoi);
        }

        public void Confirm()
        {
            foreach(var id in maDaPhat)
            {
                id.Confirm();
            }
        }
    }
}
