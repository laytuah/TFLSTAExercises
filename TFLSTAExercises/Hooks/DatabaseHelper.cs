using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLSTAExercises.Hooks
{
    public class DatabaseHelper
    {
        string connectionString = EnvironmentData.connectionString;
        public void DeleteAndUpdateJourneyRecords(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
