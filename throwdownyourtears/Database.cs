using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace throwdownyourtears
{
    internal class DB
    {
#pragma warning disable CS8618 // поле "connection", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        private DB() { }
#pragma warning restore CS8618 // поле "connection", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "instance", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        static DB instance;
#pragma warning restore CS8618 // поле "instance", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        public static DB GetInstance()
        {
            if (instance == null)
                instance = new();
            return instance;
        }

        internal void EditData(Product edit)
        {
            if (OpenConnection())
            {
                string sql = "UPDATE throwdownyourtears.products SET Name = @Name WHERE id = " + edit.Id;
                MySqlParameter[] parameters = new MySqlParameter[] {
                    new MySqlParameter("name", edit.Name),
                    new MySqlParameter("price", edit.Price),
                    new MySqlParameter("minimum", edit.Minimum),
                    new MySqlParameter("quantity", edit.Quantity),
                    new MySqlParameter("PurchasePrice", edit.PurchasePrice)
                };
                MySqlHelper.ExecuteNonQuery(connection, sql, parameters);
                connection.Close();
            }
        }

        internal void AddData(Product edit)
        {
            if (OpenConnection())
            {
                string sql = "INSERT INTO throwdownyourtears.products (name, price, minimum, quantity, PurchasePrice) VALUES (@Name, @Price, @Minimum, @Quantity, @PurchasePrice);";
                MySqlParameter[] parameters = new MySqlParameter[] {
                    new MySqlParameter("name", edit.Name),
                    new MySqlParameter("price", edit.Price),
                    new MySqlParameter("minimum", edit.Minimum),
                    new MySqlParameter("quantity", edit.Quantity),
                    new MySqlParameter("PurchasePrice", edit.PurchasePrice)
                };
                    MySqlHelper.ExecuteNonQuery(connection, sql, parameters);
                connection.Close();
            }
        }


        internal List<Product>? GetProduct()
        {
            List<Product> products = new List<Product>();
            if (OpenConnection())
            {
                string sql = "select * FROM products";
                using (var mc = new MySqlCommand(sql, connection))
                using (var reader = mc.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product provider = new Product()
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Price = reader.GetString("price"),
                            Minimum = reader.GetString("minimum"),
                            Quantity = reader.GetString("quantity"),
                            PurchasePrice = reader.GetString("PurchasePrice"),
                        };
                        products.Add(provider);
                    }
                }
                connection.Close();
            }
            return products;
        }

        internal List<Provider>? GetProvider()
        {
            List<Provider> provider = new List<Provider>();
            if (OpenConnection())
            {
                string sql = "select * FROM provider";
                using (var mc = new MySqlCommand(sql, connection))
                using (var reader = mc.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Provider products = new Provider()
                        {
                            Id1 = reader.GetInt32("id1"),
                            Telegramid = reader.GetString("telegramid"),
                            Name1 = reader.GetString("name"),
                        };
                        provider.Add(products);
                    }
                }
                connection.Close();
            }
            return provider;
        }

        internal void AddData(Provider edit)
        {
            if (OpenConnection())
            {
                string sql = "INSERT INTO throwdownyourtears.provider (telegramid, name) VALUES (@Name1, @Telegramid);";
                MySqlParameter[] parameters = new MySqlParameter[] {
                    new MySqlParameter("name", edit.Name1),
                    new MySqlParameter("telegramid", edit.Telegramid),

                };
                MySqlHelper.ExecuteNonQuery(connection, sql, parameters);
                connection.Close();
            }
        }

        public int GetNextID(string table)
        {
            int id = 0;
            if (OpenConnection())
            {
                string sql = $"SHOW TABLE STATUS FROM throwdownyourtears WHERE Name = '{table}'";
                using (var mc = new MySqlCommand(sql, connection))
                using (var dr = mc.ExecuteReader())
                {
                    if (dr.Read())
                        id = dr.GetInt32("Auto_Increment");
                }
                connection.Close();
            }
            return id;
        }
        bool OpenConnection()
        {
            if (connection == null)
                ConfigureConnection();
            try
            {
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
                connection.Open();
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }

        public void TestConnection()
        {
            if (OpenConnection())
            {
                connection.Close();
                System.Windows.MessageBox.Show("Успешно");
            }
        }

        MySqlConnection connection;
        void ConfigureConnection()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "1234512345";
            sb.Database = "throwdownyourtears";
            sb.CharacterSet = "utf8mb4";
            connection = new MySqlConnection(sb.ToString());
        }
    }
}
