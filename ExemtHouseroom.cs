using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN
{
    class ExemtHouseroom
    {
        int? id { get; set; }
        string propertyType { get; set; }
        bool isOwner { get; set; }
        float totalArea { get; set; }
        float livingArea { get; set; }
        int residentCount { get; set; }
        int roomsCount { get; set; }
        int familyMembersCount { get; set; }
        int? exemtId { get; set; }
        Exempt exempt { get; set; }
    }
}
