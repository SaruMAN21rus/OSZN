using DatabaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSZN.DAO
{
    class HouseDAO : CommonDAO
    {
        public HouseDAO(DbFacadeSQLite db)
            : base(db)
        {
            this.db = db;
        }

        public HouseDAO()
            : base()
        {
            this.db = db;
        }

        public House getAddressById(int id)
        {
            Select query = new Select()
                .From("HOUSE")
                .Where("id = " + id);
            Dictionary<string, object> h = db.FetchOneRow(query);
            House house = new House();
            house.id = Convert.ToInt32(h["id"]);
            house.postalCode = h["postal_code"].ToString();
            house.houseNumber = h["house_number"].ToString();
            house.housingNumber = h["housing_number"].ToString();
            house.roomNumber = h["room_number"].ToString();
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            house.cityOrArea = aoDAO.getAddressById(Convert.ToInt32(h["city_or_area_id"]));
            if (!String.IsNullOrEmpty(h["place_id"].ToString()))
            {
                house.place = aoDAO.getAddressById(Convert.ToInt32(h["place_id"]));
            }
            if (!String.IsNullOrEmpty(h["street_id"].ToString()))
            {
                house.street = aoDAO.getAddressById(Convert.ToInt32(h["street_id"]));
            }
            return house;
        }

        public int insertHouse(House house)
        {
            ParametersCollection parameters = new ParametersCollection();
            parameters.Add("city_or_area_id", house.cityOrArea.id, System.Data.DbType.Int32);
            if (house.place != null)
            {
                parameters.Add("place_id", house.place.id, System.Data.DbType.Int32);
            }
            if (house.street != null)
            {
                parameters.Add("street_id", house.street.id, System.Data.DbType.Int32);
            }
            parameters.Add("postal_code", house.postalCode, System.Data.DbType.String);
            parameters.Add("house_number", house.houseNumber, System.Data.DbType.String);
            parameters.Add("housing_number", house.housingNumber, System.Data.DbType.String);
            parameters.Add("room_number", house.roomNumber, System.Data.DbType.String);
            return db.Insert("house", parameters);
        }

        public void updateHouse(House house)
        {
            ParametersCollection parameters = new ParametersCollection();
            parameters.Add("city_or_area_id", house.cityOrArea.id, System.Data.DbType.Int32);
            if (house.place != null)
            {
                parameters.Add("place_id", house.place.id, System.Data.DbType.Int32);
            }
            if (house.street != null)
            {
                parameters.Add("street_id", house.street.id, System.Data.DbType.Int32);
            }
            parameters.Add("postal_code", house.postalCode, System.Data.DbType.String);
            parameters.Add("house_number", house.houseNumber, System.Data.DbType.String);
            parameters.Add("housing_number", house.housingNumber, System.Data.DbType.String);
            parameters.Add("room_number", house.roomNumber, System.Data.DbType.String);
            db.Update("house", parameters, "id = " + house.id);
        }
    }
}
