using les3.Models;
using System.Data;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Data.SqlClient;

namespace les3.Repositories
{
    public class AttachmentRepository:IAttachmentRepository
    {

        private readonly string _connectionString;

        public AttachmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public DataTable CreateAttachment(string FileName, string FilePath, string Size, string Description)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddAttachment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@FileName", FileName));
                    command.Parameters.Add(new SqlParameter("@FilePath", FilePath));
                    command.Parameters.Add(new SqlParameter("@Size", Size));
                    command.Parameters.Add(new SqlParameter("@Description", Description));

                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }


        public bool ProcessTransaction(Attachments attachment, Tasks task)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command1 = new SqlCommand("INSERT INTO Tasks (Title, Description, UserId, ProjectId)  VALUES (@Title, @Description, @UserId, @ProjectId)", connection, transaction))
                    {
                        command1.Parameters.AddWithValue("@Title", task.Title);
                        command1.Parameters.AddWithValue("@Description", task.Description);
                        command1.Parameters.AddWithValue("@UserId", task.UserId);
                        command1.Parameters.AddWithValue("@ProjectId", task.ProjectId);
                        command1.ExecuteNonQuery();
                    }

                    using (SqlCommand command2 = new SqlCommand("INSERT INTO Attachments (FileName, FilePath, Size, Description) VALUES (@FileName, @FilePath,@Size, @Description)", connection, transaction))
                    {
                        command2.Parameters.AddWithValue("@FileName", attachment.FileName);
                        command2.Parameters.AddWithValue("@FilePath", attachment.FilePath);
                        command2.Parameters.AddWithValue("@Size", attachment.Size);
                        command2.Parameters.AddWithValue("@Description", attachment.Description);
                        command2.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    Console.WriteLine("Transaction committed.");
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
