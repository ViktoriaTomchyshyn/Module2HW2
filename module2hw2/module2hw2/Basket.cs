using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Module2hw2
{
    public class Basket
    {
        private int[] _productIDs;
        public Basket()
        {
            _productIDs = null;
        }

        public bool AddProductID(int id)
        {
            if (_productIDs == null)
            {
                _productIDs = new int[1] { id };
                return true;
            }
            else if (_productIDs.Length + 1 > 10)
            {
                return false;
            }
            else
            {
                Array.Resize<int>(ref _productIDs, _productIDs.Length + 1);
                _productIDs[_productIDs.Length - 1] = id;
                return true;
            }
        }

        public int[] GetIDs()
        {
            return _productIDs;
        }

        public override string ToString()
        {
            string result = string.Empty;
            if (_productIDs != null)
            {
                for (int i = 0; i < _productIDs.Length; i++)
                {
                    result += _productIDs[i].ToString() + " ";
                }
            }

            return result;
        }
    }
}
