using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Restaurants;

namespace Restaurants.Models
{
    public class RestaurantClass
    {
        private int _id;
        private string _name;
        private string _location;
        private int _cuisineId;

        public RestaurantClass(int id, string name, string location, int cuisineId)
        {
            _id = id;
            _name = name;
            _location = location;
            _cuisineId = cuisineId;
        }

        public RestaurantClass(string name, string location, int cuisineId)
        {
            _name = name;
            _location = location;
            _cuisineId = cuisineId;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetLocation()
        {
            return _location;
        }

        public int GetCuisineId()
        {
            return _cuisineId;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restaurant (name, location, cuisineId) VALUES (@RestaurantName , @RestaurantLocation , @RestaurantCuisineId);";
            cmd.Parameters.AddWithValue("@RestaurantName" , this._name);
            cmd.Parameters.AddWithValue("@RestaurantLocation" , this._location);
            cmd.Parameters.AddWithValue("@RestaurantCuisineId" , this._cuisineId);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<RestaurantClass> GetAll()
        {
            List<RestaurantClass> allRestaurants = new List<RestaurantClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurant;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string location = rdr.GetString(2);
                int cuisineId = rdr.GetInt32(3);
                RestaurantClass newRestaurant = new RestaurantClass(id, name, location, cuisineId);
                allRestaurants.Add(newRestaurant);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allRestaurants;
        }

        public static List<RestaurantClass> FindById(int id)
        {
            List<RestaurantClass> allRestaurants = new List<RestaurantClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurant WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int idz = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                string location = rdr.GetString(2);
                int cuisineId = rdr.GetInt32(3);
                RestaurantClass newRestaurant = new RestaurantClass(idz, name, location, cuisineId);
                allRestaurants.Add(newRestaurant);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allRestaurants;
        }

            public static void Delete(int id)
            {
                MySqlConnection conn = DB.Connection();
                conn.Open();

                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"DELETE FROM restaurant WHERE id = " + id + ";";

                cmd.ExecuteNonQuery();

                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
            }

            public static List<RestaurantClass> GetAllRestaurants(int id)
            {
                List<RestaurantClass> allRestaurants = new List<RestaurantClass> {};
                MySqlConnection conn = DB.Connection();
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
                 cmd.CommandText = @"SELECT * FROM restaurant WHERE cuisineid = " + id + ";";
                MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
                while(rdr.Read())
                {
                    int idz = rdr.GetInt32(0);
                    string name = rdr.GetString(1);
                    string location = rdr.GetString(2);
                    int cuisineId = rdr.GetInt32(3);
                    RestaurantClass newRestaurant = new RestaurantClass(idz, name, location, cuisineId);
                    allRestaurants.Add(newRestaurant);
                    
                }
                conn.Close();
                if (conn !=null)
                {
                    conn.Dispose();
                }
                return allRestaurants;
            }

            public static void DeleteRestaurantByCuisineId(int id)
            {
                MySqlConnection conn = DB.Connection();
                conn.Open();

                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @"DELETE FROM restaurant WHERE cuisineid = " + id + ";";
                cmd.ExecuteNonQuery();

                conn.Close();
                if (conn != null)
                {
                    conn.Dispose();
                }
            }
    }

    public class CuisineClass
    {
        private int _id;
        private string _name;

        public CuisineClass(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public CuisineClass(string name)
        {
            _name = name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO cuisine (name) VALUES (@CuisineName);";
            cmd.Parameters.AddWithValue("@CuisineName" , this._name);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<CuisineClass> GetAll()
        {
            List<CuisineClass> allCuisines = new List<CuisineClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisine;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                string name = rdr.GetString(1);
                int id = rdr.GetInt32(0);
                CuisineClass newCuisine = new CuisineClass(id, name);
                allCuisines.Add(newCuisine);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allCuisines;
        }

        public static List<CuisineClass> FindById(int id)
        {
            List<CuisineClass> allCuisines = new List<CuisineClass> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisine WHERE id = " + id + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int idz = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                CuisineClass newCuisine = new CuisineClass(idz, name);
                allCuisines.Add(newCuisine);
                
            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allCuisines;
        }

        public static void DeleteCuisine(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM cuisine WHERE id = " + id + ";";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }
}
