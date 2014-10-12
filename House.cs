using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN
{
    public class House
    {
        public int? id { get; set; }
        public VocAddressObject cityOrArea { get; set; }
        public VocAddressObject place { get; set; }
        public VocAddressObject street { get; set; }
        public string houseNumber { get; set; }
        public string housingNumber { get; set; }
        public string roomNumber { get; set; }
        public string postalCode { get; set; }
        public string fullAddress
        {
            get
            {
                string address = "";
                if (!String.IsNullOrEmpty(postalCode))
                {
                    address += postalCode + ", ";
                }
                if (cityOrArea != null)
                {
                    address += cityOrArea.fullName + ", ";
                }
                if (place != null)
                {
                    address += place.fullName + ", ";
                }
                if (street != null)
                {
                    address += street.fullName + ", ";
                }
                if (!String.IsNullOrEmpty(houseNumber))
                {
                    address += "д. " + houseNumber + ", ";
                }
                if (!String.IsNullOrEmpty(housingNumber))
                {
                    address += "корп. " + housingNumber + ", ";
                }
                if (!String.IsNullOrEmpty(roomNumber))
                {
                    address += "кв. " + roomNumber + ", ";
                }
                return address.Substring(0, address.Length - 2);
            }
        }

    }

    public class VocAddressObject
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string typeBrief { get; set; }
        public bool typeBriefHasPoint { get; set; }
        public bool typeBriefInLeft { get; set; }

        public string fullName
        {
            get
            {
                string tb = "";
                if (typeBriefHasPoint) {
                    tb = typeBrief + "."; 
                }
                if (typeBriefInLeft)
                {
                    return tb + " " + name;
                }
                else
                {
                    return name + " " + tb;
                }
            }
        }
    }
}
