using CustomizesWebApp.MyClass;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebTest.Model;

namespace WebTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductDetails" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductDetails.svc or ProductDetails.svc.cs at the Solution Explorer and start debugging.
    public class ProductDetails : IProductDetails
    {
        General objGn = new General();
        public void DoWork()
        {

        }
        #region Product

        public checkProduct GetProduct()
        {
            checkProduct objCp = new checkProduct();

            try
            {
                DataTable dt = new DataTable();
                NameValueCollection nv = new NameValueCollection();
                nv.Add("@ProductId", "0");

                dt = objGn.GetDataTable("Get_Product", nv);

                if (dt != null)
                {
                    var lstProduct = new List<Product>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Product objPr = new Product();

                        objPr.ProductName = dt.Rows[i]["ProductName"].ToString();
                        objPr.ProductDesc = dt.Rows[i]["ProductDesc"].ToString();

                        lstProduct.Add(objPr);
                    }
                    objCp.Data = lstProduct;
                    objCp.status = true;
                    objCp.message = "Success";

                }
                else
                {
                    objCp.Data = null;
                    objCp.status = false;
                    objCp.message = "failure";
                }

            }
            catch (Exception ex)
            {
                objCp.Data = null;
                objCp.status = false;
                objCp.message = ex.Message;

            }
            return objCp;



        }


        public checkProduct GetProductId(string ProductId)
        {
            checkProduct objCp = new checkProduct();

            try
            {
                DataTable dt = new DataTable();
                NameValueCollection nv = new NameValueCollection();

                nv.Add("@ProductId", ProductId);
             
                dt = objGn.GetDataTable("Get_ProductId", nv);

                if (dt != null)
                {
                    var lstProduct = new List<Product>();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Product objPr = new Product();

                        objPr.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                        objPr.ProductName = dt.Rows[i]["ProductName"].ToString();

                        lstProduct.Add(objPr);
                    }
                    objCp.Data = lstProduct;
                    objCp.status = true;
                    objCp.message = "Success";

                }
                else
                {
                    objCp.Data = null;
                    objCp.status = false;
                    objCp.message = "failure";
                }

            }
            catch (Exception ex)
            {
                objCp.Data = null;
                objCp.status = false;
                objCp.message = ex.Message;

            }
            return objCp;



        }


        public checkAddProduct AddProduct(string ProductName, string ProductDesc)
        {
            checkAddProduct objCheckp = new checkAddProduct();
            try
            {
                int IsResult = 0;
                DataTable dt = new DataTable();
                NameValueCollection nv = new NameValueCollection();
                nv.Add("@ProductId", "0");
                nv.Add("@ProductName", ProductName);
                nv.Add("@ProductDesc", ProductDesc);

                IsResult = objGn.GetDataExecuteScaler("Set_AddProduct", nv);

                if (IsResult > 0)
                {
                    objCheckp.ProductId = IsResult.ToString();
                    objCheckp.status = true;
                    objCheckp.message = "Success";
                }
                else
                {
                    objCheckp.ProductId = "0";
                    objCheckp.status = false;
                    objCheckp.message = "Failure";
                }

            }
            catch (Exception ex)
            {
                objCheckp.ProductId = "0";
                objCheckp.status = false;
                objCheckp.message = ex.Message;


            }

            return objCheckp;



        }

        public checkAddProduct EditProduct(string ProductId, string ProductName, string ProductDesc)
        {
            checkAddProduct objCheckp = new checkAddProduct();
            try
            {
                int IsResult = 0;
                DataTable dt = new DataTable();
                NameValueCollection nv = new NameValueCollection();
                nv.Add("@ProductId", ProductId);
                nv.Add("@ProductName", ProductName);
                nv.Add("@ProductDesc", ProductDesc);

                IsResult = objGn.GetDataExecuteScaler("Set_EditProduct", nv);

                if (IsResult > 0)
                {
                    objCheckp.ProductId = IsResult.ToString();
                    objCheckp.status = true;
                    objCheckp.message = "Success";
                }
                else
                {
                    objCheckp.ProductId = "0";
                    objCheckp.status = false;
                    objCheckp.message = "Failure";
                }

            }
            catch (Exception ex)
            {
                objCheckp.ProductId = "0";
                objCheckp.status = false;
                objCheckp.message = ex.Message;


            }

            return objCheckp;

        }


        public checkAddProduct DeleteProduct(string ProductId)
        {
            checkAddProduct objCheckp = new checkAddProduct();
            try
            {
                int IsResult = 0;
                DataTable dt = new DataTable();
                NameValueCollection nv = new NameValueCollection();
                nv.Add("@ProductId", ProductId);

                IsResult = objGn.GetDataExecuteScaler("Set_DeleteProduct", nv);

                if (IsResult > 0)
                {
                    objCheckp.ProductId = IsResult.ToString();
                    objCheckp.status = true;
                    objCheckp.message = "Success";
                }
                else
                {
                    objCheckp.ProductId = "0";
                    objCheckp.status = false;
                    objCheckp.message = "Failure";
                }

            }
            catch (Exception ex)
            {
                objCheckp.ProductId = "0";
                objCheckp.status = false;
                objCheckp.message = ex.Message;


            }

            return objCheckp;


        }

        #endregion
    }
}
