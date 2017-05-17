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
        private int selledNumber;

        public BestSelling(int productid, int selledNum)
        {
            this.productId = productid;
            this.selledNumber = selledNum;
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

        public int SelledNumber
        {
            get
            {
                return selledNumber;
            }

            set
            {
                selledNumber = value;
            }
        }
    }
}
