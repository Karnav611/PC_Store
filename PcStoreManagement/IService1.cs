using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PcStoreManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        string AddProduct(Product prod);

        [OperationContract]
        DataSet GetProduct();

        [OperationContract]
        string DeleteProduct(Product prod);

        [OperationContract]
        DataSet SearchProduct(Product prod);

        [OperationContract]
        string UpdateProduct(Product prod);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "PcStoreManagement.ContractType".
    [DataContract]
    public class Product
    {

        string id = "";
        string name = "";
        string brand = "";
        string price = "";
        string warranty = "";
        string description = "";

        [DataMember]
        public string ProdId
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        [DataMember]
        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public string Warranty
        {
            get { return warranty; }
            set { warranty = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}

