using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAO
{
    public class CategoryDAO : DataProvider
    {
        public List<Category> GetData()
        {
            List<Category> list = new List<Category>();

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_GetAll_LoaiGiay", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Category(
                        dr["MaLoaiGiay"].ToString().Trim(),
                        dr["TenLoaiGiay"].ToString().Trim()
                    ));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn loại giày (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }

        public bool Insert(Category c)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_Insert_LoaiGiay", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaLoaiGiay", c.MaLoaiGiay);
                cmd.Parameters.AddWithValue("@TenLoaiGiay", c.TenLoaiGiay);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                // Nếu SP RAISERROR, nó ném SqlException
                throw new Exception("Lỗi thêm loại giày (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool Update(Category c)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_Update_LoaiGiay", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaLoaiGiay", c.MaLoaiGiay);
                cmd.Parameters.AddWithValue("@TenLoaiGiay", c.TenLoaiGiay);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật loại giày (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool Delete(string ma)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_Delete_LoaiGiay", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLoaiGiay", ma);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa loại giày (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
