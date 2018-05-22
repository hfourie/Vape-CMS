using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Vape.CMS.DAL.DTO;
using Vape.CMS.DAL.Entities;

namespace Vape.CMS.DAL.Functions
{
    public static class ProductFunctions
    {
        private static readonly Database Db = new Database();

        #region Product Specific Functions
        //get Products
        public static List<Product> GetAll()
        {
            var sqlQuery = $"SELECT * FROM products WHERE Deleted = False";
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);

            return dt.AsEnumerable().Select(row =>
                new Product
                {
                    ProductId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["ProductId"])),
                    Name = SqlHelperFunctions.NullCheck(row["Name"]),
                    Amount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Amount"])),
                    Discount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Discount"]))

                }).ToList();
        }

        //get Product
        public static Product Get(Product product)
        {
            var sqlQuery = $"SELECT * FROM products WHERE ProductId = @ProductId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductId", product.ProductId)
            };
            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);

            if (dt.Rows.Count > 0)
            {
                product.ProductId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["ProductId"]));
                product.CategoryId = Convert.ToInt32(SqlHelperFunctions.NullCheck(dt.Rows[0]["CategoryId"]));
                product.Name = SqlHelperFunctions.NullCheck(dt.Rows[0]["Name"]);
                product.Amount = Convert.ToDouble(SqlHelperFunctions.NullCheck(dt.Rows[0]["Amount"]));
                product.Discount = Convert.ToDouble(SqlHelperFunctions.NullCheck(dt.Rows[0]["Discount"]));
                product.Description = SqlHelperFunctions.NullCheck(dt.Rows[0]["Description"]);
            };

            return product;
        }

        //create Product
        public static int Create(Product product)
        {
            var sqlQuery = "INSERT INTO products (ProductGuId, CategoryId, Name, Amount, Discount, Description, Updated) VALUES (@ProductGuId, @CategoryId, @Name, @Amount, @Discount, @Description, @Updated); " +
                           "SELECT LAST_INSERT_ID() as ProductId";

            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductGuId", Guid.NewGuid()),
                new MySqlParameter("@CategoryId", product.CategoryId),
                new MySqlParameter("@Name", product.Name),
                new MySqlParameter("@Amount", product.Amount),
                new MySqlParameter("@Discount", product.Discount),
                new MySqlParameter("@Description", product.Description),
                new MySqlParameter("@Updated", DateTime.Now)
            };

            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.DataTable, false);

            return (dt.Rows.Count > 0) ? int.Parse(dt.Rows[0]["ProductId"].ToString()) : 0;
        }

        //update Product
        public static void Update(Product product)
        {
            var sqlQuery = "UPDATE Products SET CategoryId = @CategoryId, Name = @Name, Amount = @Amount, Discount = @Discount, Description = @Description, Updated = @Updated WHERE ProductId = @ProductId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@CategoryId", product.CategoryId),
                new MySqlParameter("@Name", product.Name),
                new MySqlParameter("@Amount", product.Amount),
                new MySqlParameter("@Discount", product.Discount),
                new MySqlParameter("@Description", product.Description),
                new MySqlParameter("@Updated", DateTime.Now),
                new MySqlParameter("@ProductId", product.ProductId)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //delete Product
        public static void Delete(Product product)
        {
            var sqlQuery = "UPDATE Products SET Deleted = False WHERE ProductId = @ProductId";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductId", product.ProductId)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }
        #endregion

        #region Product Color Functions
        //create product color tie
        public static void CreateProductColorTie(ProductColorTie productColorTie)
        {
            var sqlQuery = "INSERT INTO productcolortie (ProductId, ColorId, Amount, Discount, Stock, Updated) VALUES (@ProductId, @ColorId, @Amount, @Discount, @Stock, @Updated) ";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductId", productColorTie.ProductId),
                new MySqlParameter("@ColorId", productColorTie.ColorId),
                new MySqlParameter("@Amount", productColorTie.ColorAmount),
                new MySqlParameter("@Discount", productColorTie.ColorDiscount),
                new MySqlParameter("@Stock", productColorTie.ColorStock),
                new MySqlParameter("@Updated", DateTime.Now)
            };

            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update product color tie 
        public static void UpdateProductColorTie(ProductColorTie productColorTie)
        {
            var sqlQuery = @"   UPDATE productcolortie SET 
                                ColorId = @ColorId, 
                                Amount = @Amount, 
                                Discount = @Discount, 
                                Stock = @Stock, 
                                Updated = @Updated 
                                WHERE ProductColorTieId = @ProductColorTieId
                            ";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductColorTieId", productColorTie.ProductColorTieId),
                new MySqlParameter("@ColorId", productColorTie.ColorId),
                new MySqlParameter("@Amount", productColorTie.ColorAmount),
                new MySqlParameter("@Discount", productColorTie.ColorDiscount),
                new MySqlParameter("@Stock", productColorTie.ColorStock),
                new MySqlParameter("@Updated", DateTime.Now)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        // Get Colors
        public static List<ProductColorTieListDto> GetAllProductColors()
        {
            var sqlQuery = @"   SELECT pct.*, c.* FROM productcolortie pct
                                INNER JOIN colors c ON c.colorId = pct.colorId
                                WHERE pct.Deleted = False
                            ";

            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);

            return dt.AsEnumerable().Select(row =>
                new ProductColorTieListDto
                {
                    ProductColorTieId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["ProductColorTieId"])),
                    ColorId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["ColorId"])),
                    Color = SqlHelperFunctions.NullCheck(row["Color"]),
                    ColorAmount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Amount"])),
                    ColorDiscount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Discount"])),
                    ColorStock = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["Stock"])),

                }).ToList();
        }

        #endregion

        #region Product Nicotine Functions

        //create product nicotine tie
        public static void CreateProductNicotineTie(ProductNicotineTie productNicotineTie)
        {
            var sqlQuery = "INSERT INTO productnicotinetie (ProductId, NicotineId, Amount, Discount, Stock, Updated) VALUES (@ProductId, @NicotineId, @Amount, @Discount, @Stock, @Updated) ";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductId", productNicotineTie.ProductId),
                new MySqlParameter("@NicotineId", productNicotineTie.NicotineId),
                new MySqlParameter("@Amount", productNicotineTie.NicotineAmount),
                new MySqlParameter("@Discount", productNicotineTie.NicotineDiscount),
                new MySqlParameter("@Stock", productNicotineTie.NicotineStock),
                new MySqlParameter("@Updated", DateTime.Now)
            };

            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update product nicotine tie 
        public static void UpdateProductNicotineTie(ProductNicotineTie productNicotineTie)
        {
            var sqlQuery = @"   UPDATE productnicotinetie SET 
                                NicotineId = @NicotineId, 
                                Amount = @Amount, 
                                Discount = @Discount, 
                                Stock = @Stock, 
                                Updated = @Updated 
                                WHERE ProductNicotineTieId = @ProductNicotineTieId
                            ";

            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductNicotineTieId", productNicotineTie.ProductNicotineTieId),
                new MySqlParameter("@NicotineId", productNicotineTie.NicotineId),
                new MySqlParameter("@Amount", productNicotineTie.NicotineAmount),
                new MySqlParameter("@Discount", productNicotineTie.NicotineDiscount),
                new MySqlParameter("@Stock", productNicotineTie.NicotineStock),
                new MySqlParameter("@Updated", DateTime.Now),
            };

            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        // Get Nicotine
        public static List<ProductNicotineTieListDto> GetAllProductNicotine()
        {
            var sqlQuery = @"   SELECT pnt.*, n.* FROM productnicotinetie pnt
                                INNER JOIN nicotine n ON n.nicotineId = pnt.nicotineId
                                WHERE pnt.Deleted = False
                            ";

            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);

            return dt.AsEnumerable().Select(row =>
                new ProductNicotineTieListDto
                {
                    ProductNicotineTieId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["ProductNicotineTieId"])),
                    NicotineId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["NicotineId"])),
                    Nicotine = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Nicotine"])),
                    NicotineAmount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Amount"])),
                    NicotineDiscount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Discount"])),
                    NicotineStock = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["Stock"])),

                }).ToList();
        }

        #endregion

        #region Product Size Functions
        //create product Size tie
        public static void CreateProductSizeTie(ProductSizeTie productSizeTie)
        {
            var sqlQuery = "INSERT INTO productsizetie (ProductId, SizeId, Amount, Discount, Stock, Updated) VALUES (@ProductId, @SizeId, @Amount, @Discount, @Stock, @Updated) ";
            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductId", productSizeTie.ProductId),
                new MySqlParameter("@SizeId", productSizeTie.SizeId),
                new MySqlParameter("@Amount", productSizeTie.SizeAmount),
                new MySqlParameter("@Discount", productSizeTie.SizeDiscount),
                new MySqlParameter("@Stock", productSizeTie.SizeStock),
                new MySqlParameter("@Updated", DateTime.Now)
            };

            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        //update product Size tie 
        public static void UpdateProductSizeTie(ProductSizeTie productSizeTie)
        {
            var sqlQuery = @"   UPDATE productsizetie SET 
                                SizeId = @SizeId, 
                                Amount = @Amount, 
                                Discount = @Discount, 
                                Stock = @Stock, 
                                Updated = @Updated 
                                WHERE ProductSizeTieId = @ProductSizeTieId
                            ";

            var sqlParams = new List<MySqlParameter>() {
                new MySqlParameter("@ProductSizeTieId", productSizeTie.ProductSizeTieId),
                new MySqlParameter("@SizeId", productSizeTie.SizeId),
                new MySqlParameter("@Amount", productSizeTie.SizeAmount),
                new MySqlParameter("@Discount", productSizeTie.SizeDiscount),
                new MySqlParameter("@Stock", productSizeTie.SizeStock),
                new MySqlParameter("@Updated", DateTime.Now)
            };
            Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, sqlParams.ToArray(), Database.ReturnType.None, false);
        }

        // Get Sizes
        public static List<ProductSizeTieListDto> GetAllProductSizes()
        {
            var sqlQuery = @"   SELECT pst.*, s.* FROM productsizetie pst
                                INNER JOIN sizes s ON s.sizeId = pst.sizeId
                                WHERE pst.Deleted = False
                            ";

            var dt = (DataTable)Db.ExecDb(sqlQuery, Database.DatabaseProcedureType.Text, null, Database.ReturnType.DataTable, false);

            return dt.AsEnumerable().Select(row =>
                new ProductSizeTieListDto
                {
                    ProductSizeTieId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["ProductSizeTieId"])),
                    SizeId = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["SizeId"])),
                    Size = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["Size"])),
                    SizeAmount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Amount"])),
                    SizeDiscount = Convert.ToDouble(SqlHelperFunctions.NullCheck(row["Discount"])),
                    SizeStock = Convert.ToInt32(SqlHelperFunctions.NullCheck(row["Stock"])),

                }).ToList();
        }

        #endregion

    }
}



