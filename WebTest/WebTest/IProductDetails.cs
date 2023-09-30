using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WebTest.Model;

namespace WebTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductDetails" in both code and config file together.
    [ServiceContract]
    public interface IProductDetails
    {
        [OperationContract]
        void DoWork();

        #region Product
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetProduct", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkProduct GetProduct();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetProductId/{ProductId}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkProduct GetProductId(string productId);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddProduct", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkAddProduct AddProduct(string ProductName, string ProductDesc);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "EditProduct/{ProductId}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkAddProduct EditProduct(string ProductId, string ProductName, string ProductDesc);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteProduct/{ProductId}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkAddProduct DeleteProduct(string ProductId);
        #endregion
    }
}
