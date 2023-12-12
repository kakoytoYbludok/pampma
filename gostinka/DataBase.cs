using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace gostinka
{
    class DataBaseClass
    {
        public static string DS = "DESKTOP-11K9QOU\\GEREXPRESS", IC = "gostinka";

        public static string Users_ID = "null", Password = "null", App_Name = "Гостиница";

        public static string ConnectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = true;", DS, IC, "; Persist Security Info = true; User ID = sa; Password = 123");

        public SqlConnection connection = new SqlConnection(ConnectionString);

        private SqlCommand command = new SqlCommand();

        public DataTable resultTable = new DataTable();

        public SqlDependency dependency = new SqlDependency();

        public enum act { select, manipulation };
        public int ExecuteQuery(string query)
        {
            using(SqlConnection connection = new SqlConnection(ConnectionString))
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
                using(SqlCommand command = new SqlCommand(selectquery, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    using(SqlDataReader reader = command.ExecuteReader())
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





//internal class DataBase
//{
//    public static string DS = "DESKTOP-11K9QOU\\GEREXPRESS", IC = "gostinka";

//    public static string Users_ID = "null", Password = "null", App_Name = "Гостиница";

//    public static string ConnectionString = string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = true;", DS, IC, "; Persist Security Info = true; User ID = sa; Password = 123");

//    public SqlConnection connection = new SqlConnection(ConnectionString);

//    private SqlCommand command = new SqlCommand();

//    public DataTable resultTable = new DataTable();

//    public SqlDependency dependency = new SqlDependency();

//    private static DataBase instance;
//    public static DataBase Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = new DataBase();
//            }
//            return instance;
//        }

//    }
//    public DataTable GetDataTable(String query)
//    {
//        DataTable dataTable = new DataTable();
//        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
//        {
//            connection.Open();
//            using (MySqlCommand command = new MySqlCommand(query, connection))
//            {
//                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
//                {
//                    adapter.Fill(dataTable);
//                }
//            }

//        }
//        return dataTable;
//        //dataGrid.ItemsSource = dbManager.GetTableData(query).DefaultView;
//    }

//public void sqlExecute(string quety)
//{
//    command.Connection = connection;

//    command.CommandText = quety;

//    command.Notification = null;

//    switch (act)
//    {
//        case act.select:

//            dependency.AddCommandDependency(command);

//            SqlDependency.Start(connection.ConnectionString);

//            connection.Open();

//            resultTable.Load(command.ExecuteReader());////////////////

//            connection.Close();

//            break;

//        case act.manipulation:

//            connection.Open();

//            try
//            {
//                command.ExecuteNonQuery();
//            }
//            catch (Exception e)
//            {
//                MessageBox.Show(e.ToString());
//            }

//            break;
//            connection.Close();

//            break;
//    }
//}


//    }
//}


