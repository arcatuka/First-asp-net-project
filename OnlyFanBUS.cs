using OnlyFanSite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class OnlyFanBUS
    {
        public List<OnlyFan> GetAll()
        {
            List<OnlyFan> OnlyFans = new OnlyFanDAO().SelectAll();
            return OnlyFans;
        }

        public OnlyFan GetDetails(int code)
        {
            OnlyFan onlyfan = new OnlyFanDAO().SelectByID(code);
            return onlyfan;
        }

        public List<OnlyFan> Search(String keyword)
        {
            List<OnlyFan> onlyFans = new OnlyFanDAO().SelectByKeyword(keyword);
            return onlyFans;
        }

        public bool AddNew(OnlyFan onlyFan)
        {
            bool result = new OnlyFanDAO().Insert(onlyFan); 
            return result;
        }

        public bool Update(OnlyFan onlyFan)
        {
            bool result = new OnlyFanDAO().Update(onlyFan);
            return result;
        }

        public bool Delete(int code)
        {
            bool result = new OnlyFanDAO().Delete(code);
            return result;
        }
    }

