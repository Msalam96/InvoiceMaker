using InvoiceMaker.Data;
using InvoiceMaker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InvoiceMaker.Repositories
{
    public class WorkDoneRepository
    {
        private Context _context;
        private string _connectionString;

        public WorkDoneRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["InvoiceDatabase"].ConnectionString;
        }

        public WorkDoneRepository(Context context)
        {
            _context = context;
        }

        public List<WorkDone> GetWorkDones()
        {
            return _context.WorkDones
                .Include(c => c.Client)
                .Include(wt => wt.WorkType)
                .OrderBy(c => c.Client.Name)
                .ToList();
        }

        public WorkDone GetById(int id)
        {
            return _context.WorkDones
                .Include(c => c.Client)
                .Include(wt => wt.WorkType)
                .OrderBy(c => c.Client.Name)
                .SingleOrDefault(wd => wd.Id == id);
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();

            //    string sql = @"
            //        SELECT wd.Id, wd.ClientId, wd.WorkTypeId, wd.StartedOn,
            //                wd.EndedOn, c.ClientName, c.IsActivated,
            //                wt.WorkTypeName, wt.Rate
            //        FROM WorkDone AS wd
            //        JOIN Client AS c ON (wd.ClientId = c.Id)
            //        JOIN WorkType AS wt ON (wd.WorkTypeId = wt.Id)
            //        WHERE wd.Id = @id
            //    ";
            //    SqlCommand command = new SqlCommand(sql, connection);
            //    command.Parameters.AddWithValue("@id", id);
            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        int wdId = reader.GetInt32(0);
            //        int wdClientId = reader.GetInt32(1);
            //        int wdWorkTypeId = reader.GetInt32(2);
            //        DateTimeOffset wdStartedOn = reader.GetDateTimeOffset(3);
            //        DateTimeOffset? wdEndedOn = null;
            //        if (!reader.IsDBNull(4))
            //        {
            //            wdEndedOn = reader.GetDateTimeOffset(4);
            //        }
            //        string cClientName = reader.GetString(5);
            //        bool cIsActivated = reader.GetBoolean(6);
            //        string wtWorkTypeName = reader.GetString(7);
            //        decimal wtRate = reader.GetDecimal(8);
            //        Client client = new Client(wdClientId, cClientName, cIsActivated);
            //        WorkType workType = new WorkType(wdWorkTypeId, wtWorkTypeName, wtRate);

            //        if (wdEndedOn.HasValue)
            //        {
            //            return new WorkDone(wdId, client, workType, wdStartedOn, wdEndedOn.Value);
            //        }
            //        else
            //        {
            //            return new WorkDone(wdId, client, workType, wdStartedOn);
            //        }
            //    }
        //}
        //    return null;
        }

        public void Insert(WorkDone workDone)
        {
            _context.WorkDones.Add(workDone);
            _context.SaveChanges();
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();

            //    string sql = @"
            //      INSERT INTO WorkDone(ClientId, WorkTypeId, StartedOn)
            //      VALUES
            //      (@clientId, @workTypeId, @startedOn)
            //    ";
            //    SqlCommand command = new SqlCommand(sql, connection);
            //    command.Parameters.AddWithValue("@clientId", workDone.ClientId);
            //    command.Parameters.AddWithValue("@workTypeId", workDone.WorkTypeId);
            //    command.Parameters.AddWithValue("@startedOn", workDone.StartedOn);
            //    command.ExecuteNonQuery();
            //}
        }

        public void Update(WorkDone workDone)
        {
            _context.WorkDones.Attach(workDone);
            _context.Entry(workDone).State = EntityState.Modified;
            _context.SaveChanges();
            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    connection.Open();

            //    string sql = @"
            //      UPDATE WorkDone
            //      SET ClientId = @clientId
            //        , WorkTypeId = @workTypeId
            //        , StartedOn = @startedOn
            //      WHERE Id = @id
            //    ";
            //    SqlCommand command = new SqlCommand(sql, connection);
            //    command.Parameters.AddWithValue("@clientId", workDone.ClientId);
            //    command.Parameters.AddWithValue("@workTypeId", workDone.WorkTypeId);
            //    command.Parameters.AddWithValue("@startedOn", workDone.StartedOn);
            //    command.Parameters.AddWithValue("@id", workDone.Id);
            //    command.ExecuteNonQuery();
            //}
        }
    }
}