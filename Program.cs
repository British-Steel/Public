using System;
using RestSharp;

namespace invoices
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter an invoice barcode: ");
            var barcode = Console.ReadLine();

            Console.WriteLine("Retrieve or Write invoice with barcode [" + barcode + "]? Enter [r/w]: ");
            var ans = Console.ReadKey();

          
            Console.WriteLine("\n\n");


            if (ans.KeyChar == 'r')
            {
                GetFromEndpoint(barcode);

            } 
            else if (ans.KeyChar == 'w')
            {

                Invoice invoice = new Invoice();
 
                invoice.barcode = barcode;
                invoice.received_date = DateTime.Now.ToString("yyyy-MM-dd");
                invoice.company = "Currys World";

                PostToEndpoint(invoice);
                
            }

            Console.WriteLine("\n\nPress 'x' to exit");
            while (Console.ReadKey().KeyChar != 'x' )
            {
            };
            

        
        }

        static void GetFromEndpoint( string barcode )
        {

            //var client = new RestClient("http://localhost:8080");
            //var client = new RestClient("http://scinfraco2.pc.scunthorpe.corusgroup.com:8075");
            var client = new RestClient("http://scironco1.pc.scunthorpe.corusgroup.com:8075");

            var request = new RestRequest("invoice/" + barcode);

            var response = client.Get(request);

            Console.Write(response.Content);
        }

        static void PostToEndpoint ( Invoice invoice )
        {
            //var client = new RestClient("http://localhost:8080");
            //var client = new RestClient("http://scinfraco2.pc.scunthorpe.corusgroup.com:8075");
            var client = new RestClient("http://scironco1.pc.scunthorpe.corusgroup.com:8075");

            var request = new RestRequest("invoice");
            request.RequestFormat = DataFormat.Json;
            request.AddBody(invoice);

            var response = client.Post(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.Write(response.Content);
            }
            else
            {
                Console.WriteLine("Post error " + response.StatusCode.ToString());
            }
        }


    }

    class Invoice
    {
        public string barcode = "";
        public string company = "British Steel";
        public int wi_id = 0;
        public int bukrs = 0;
        public string received_date = "1000-01-01";
        public string legal_name = "";
        public string trading_name = "";
        public string postal_code ="";
        public string country = "";
        public string vat_registration_number = "";
        public string tax_number = "";
        public string email = "";
        public string iban = "";
        public string bank_key = "";
        public string bank_account = "";
        public string swift = "";
        public string vendor_number = "";
        public string debit_credit = "";
        public string reference = "";
        public string tax_point_date = "1000-01-01";
        public float freight_delivery_cost = 0;
        public float discount = 0;
        public string currency ="";
        public float net_amount =0;
        public string tax_code = "";
        public float vat_amount = 0;
        public float invoice_amount = 0;
        public float exchange_rate = 0;
        public string fi_doc_yr ="";
        public string fi_doc_comp ="";
        public string fi_doc_nr = "";
        public string status ="";
        public string audit_status = "";
        public string group_id = "";
        public string agent_group = "";
        public string return_type = "";
        public string ae_date="1000-01-01";

    }
}
