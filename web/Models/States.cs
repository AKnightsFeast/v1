using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

namespace web.Models
{
    public static class States
    {
        static Dictionary<string, string> _states = new Dictionary<string, string>();

        public static Dictionary<string, string> Collection
        {
            get
            {
                if (_states.Count == 0) Load();

                return _states;
            }
        }

        public static void Load()
        {
            using (var conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["AKnightsFeast"].ConnectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select Abbr, Name from States order by Name";

                    using (var reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            _states.Add((string)reader["Abbr"], (string)reader["Name"]);
                        }
                    }
                }

                conn.Close();
            }
        }
    }
}