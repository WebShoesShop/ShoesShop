using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    public class BestSelling
    {
        private int productId;
        private int selledNum;

        public BestSelling(int id, int num)
        {
            this.productId = id;
            this.selledNum = num;
        }

        public int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                productId = value;
            }
        }

        public int SelledNum
        {
            get
            {
                return selledNum;
            }

            set
            {
                selledNum = value;
            }
        }
    }
}
