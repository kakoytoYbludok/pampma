using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace gostinka
{
    class DataBaseClass
    {
        public static string DS = "DESKTOP-FJMBK7D\\DOKA", IC = "gostinka";

        public static string Users_ID = "null", Password = "null", App_Name = "Гостиница";

        public static string ConnectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = true;", DS, IC, "; Persist Security Info = true; User ID = sa; Password = 123");

        public SqlConnection connection = new SqlConnection(ConnectionString);

        private SqlCommand command = new SqlCommand();

        public DataTable resultTable = new DataTable();

        public SqlDependency dependency = new SqlDependency();

        public enum act { select, manipulation };
        public int ExecuteQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool loginuser(string login, string password)
        {
            string selectquery = "select count(*) as usercount from dbo.[Buyer] where Login_Buyer=@Login and Password_Buyer=@Password";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int usercount = reader.GetInt32(reader.GetOrdinal("usercount"));
                            return usercount > 0;

                        }
                        return false;
                    }

                }
            }
        }



        public bool loginAdmin(string loginadm, string passwordadm)
        {
            string selectquery = "select count(*) as usercount from dbo.[Sotrudnik] where Login_Sotrudnik=@Loginadm and Password_Sotrudnik=@Passwordadm";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    command.Parameters.AddWithValue("@Loginadm", loginadm);
                    command.Parameters.AddWithValue("@Passwordadm", passwordadm);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int usercount = reader.GetInt32(reader.GetOrdinal("usercount"));
                            return usercount > 0;

                        }
                        return false;
                    }

                }
            }
        }

        public DataTable Getcolumndata(string tablename, string columnname)
        {
            string selectquery = $"select distinct {columnname} from {tablename}";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }



        }








        public DataTable GetTypeBed(string vidnomera)
        {
            string selectquery = $"select distinct Bed from [dbo].InfoNomer where VidNomera = '{vidnomera}' ";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }

        }
        public DataTable GetNomer(string vidnomera, string typebed)
        {
            string selectquery = $"select distinct NumberNomer from [dbo].InfoNomer where VidNomera = '{vidnomera}' and Bed = '{typebed}'";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }

        }

        public int GetCost(string typebed)
        {
            string selectquery = $"select PriceNomer from [dbo].InfoNomer where Bed = '{typebed}'";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1;
                }
            }

        }

        public int GetCostUsluga(string typeusluga)
        {
            int Id = -1;
            switch (typeusluga)
            {
                case "Завтрак в номер":
                    Id = 1;
                    break;

                case "Обед в номер":
                    Id = 2;
                    break;

                case "Ужин в номер":
                    Id = 3;
                    break;
            }

            string selectquery = $"select PricePokraska from [dbo].Uslugi where Id_Uslugi = {Id}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1;
                }
            }

        }



        public int GetCostUsluga2(string typeusluga2)
        {
            int Id = -1;
            switch (typeusluga2)
            {
                case "Maccаж ног":
                    Id = 1;
                    break;

                case "Maccаж головы":
                    Id = 2;
                    break;

                case "Maccаж всего тела":
                    Id = 3;
                    break;
            }

            string selectquery = $"select PriceGirl from [dbo].Uslugi where Id_Uslugi = {Id}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1;
                }
            }

        }

        public int GetCostUsluga3(string typeusluga3)
        {
            int Id = -1;
            switch (typeusluga3)
            {
                case "CПА для волос":
                    Id = 1;
                    break;

                case "CПА для для лица":
                    Id = 2;
                    break;

                case "CПА для тела":
                    Id = 3;
                    break;
            }

            string selectquery = $"select PriceMan from [dbo].Uslugi where Id_Uslugi = {Id}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1;
                }
            }

        }

        public int GetCostUsluga4(string typeusluga4)
        {
            int Id = -1;
            switch (typeusluga4)
            {
                case "Уборка в номере":
                    Id = 1;
                    break;

                case "Уборка разбитой пасуды":
                    Id = 2;
                    break;

                case "Вынос мусора":
                    Id = 3;
                    break;
            }

            string selectquery = $"select PriceManik from [dbo].Uslugi where Id_Uslugi = {Id}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return -1;
                }
            }

        }



       //public int GetTotalPrice(Buyer_ID)



        public string[] GetUserData(string Login)
        {
            string query = $"select Login_Buyer, Mail_Buyer, Phone_Buyer from [dbo].[Buyer] where Login_Buyer = '{Login}'";
            string[] data = new string[3];

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            data[0] = reader.GetString(0);
                            data[1] = reader.GetString(1);
                            data[2] = reader.GetString(2);
                        }
                        return data;

                    }
                }
            }
        }


        public void InsertZakaz(DateTime? Datezasel, DateTime? Datevisel, int ItogPrice, string SposobOplati, int Infonomer_ID, string Login_Buyer)
        {
            string insertquery = $"insert into Zakaz (Datezasel, Datevisel, ItogPrice, SposobOplati, Infonomer_ID, Login_Buyer) values ('{Datezasel}', '{Datevisel}', '{ItogPrice}', '{SposobOplati}', '{Infonomer_ID}', '{Login_Buyer}')";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertquery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertUsluga(string UslugaName, int ItogPrice, string Login_Buyer)
        {
            string insertquery = $"insert into ZakazUslug (Buyer_Login, NameUsluga, ItogPrice) values ('{Login_Buyer}', '{UslugaName}', '{ItogPrice}')";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(insertquery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }



        public int GetInfoNomerID(int numbernomer)
        {
            string selectquery = $"select ID_Infonomer from [dbo].[Infonomer] where NumberNomer = {numbernomer}";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int infonomerID = reader.GetInt32(0);
                            return infonomerID;
                        }
                        return -1;
                    }
                }
            }
        }


        public DataTable GetUsersZakaz( string Buyer_Login)
        {
            DataTable datatable = new DataTable();
            string selectquery = $"select [dbo].[Zakaz].Datezasel, Datevisel, NumberNomer, Vidnomera, Bed,SposobOplati,ItogPrice from [dbo].[Zakaz] join [dbo].[Buyer] on [dbo].[Buyer].Login_Buyer = '{Buyer_Login}' join [dbo].[InfoNomer] on [dbo].[InfoNomer].[ID_Infonomer]=[dbo].[Zakaz].[Infonomer_ID]";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter (command))
                    {
                        adapter.Fill(datatable);
                    }
                    
                }
            }
            return datatable;
        }

        public DataTable GetUsersZakazUslug(string Buyer_Login)
        {
            DataTable datatable = new DataTable();
            string selectquery = $"select [dbo].[ZakazUslug].Buyer_Login, NameUsluga, ItogPrice from [dbo].[ZakazUslug] join [dbo].[Buyer] on [dbo].[Buyer].Login_Buyer = '{Buyer_Login}'";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(datatable);
                    }

                }
            }
            return datatable;
        }




        public void sqlExecute(string quety, act act)
        {
            command.Connection = connection;

            command.CommandText = quety;

            command.Notification = null;

            switch (act)
            {
                case act.select:

                    dependency.AddCommandDependency(command);

                    SqlDependency.Start(connection.ConnectionString);

                    connection.Open();

                    resultTable.Load(command.ExecuteReader());////////////////

                    connection.Close();

                    break;

                case act.manipulation:

                    connection.Open();

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }


                    connection.Close();

                    break;
            }
        }
    }
}





