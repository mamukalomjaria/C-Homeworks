internal class Program
{
    public class Customers
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }

    }

    public static void Main(string[] args)
    {
        string[] data = File.ReadAllLines(@"../../../Customers.csv");

    }

    public static List<Customer> GetAllCustomers(string[] data)
    {
        List<Customers> customers = new List<Customers>();

        for (int i = 1; i < data.Length; i++)
        {
            customers.Add(LineToCustomer(data[i]));
        }
        return customers;
    }

    public static Customer LineTocustomer(string line)
    {
        var customerAtributes = line.Split(',');
        return new Customer(
            int.Parse(customerAtributes[0]),
            customerAtributes[1],
            int.Parse(customerAtributes[2]),
            int.Parse(customerAtributes[3]),
            customerAtributes[4],
            int.Parse(customerAtributes[5])
            );
    }

    public static Customer GetSingleCustomer(int customerId)
    {
        foreach (var customer in customers)
        {
            if (customer.Id == customerId)
            {
                return customer;
            }
        }
    }

    public static int AddCustomer(Customer model)
    {
        var sw = File.AppendText(@"../../../Customers.csv");

        sw.WriteLine($"{model.Id},{model.Name},{model.IdentityNumber},{model.PhoneNumber},{model.Email},{model.Type}");

        return model.Id;
    }

    public static int UpdateCustomer(Customer model)
    {
        var customers = GetAllCustomers(File.ReadAllLines(@"../../../Customers.csv"));

        foreach (var customer in customers)
        {
            if (customer.Id == model.Id)
            {
                customer.Name = model.Name;
                customer.IdentityNumber = model.IdentityNumber;
                customer.PhoneNumber = model.PhoneNumber;
                customer.Email = model.Email;
                customer.Type = model.Type;
            }
        }

        return model.Id;
    }

    public static int DeleteCustomer(int customerId)
    {
        var customers = GetAllCustomers(File.ReadAllLines(@"../../../Customers.csv"));

        foreach (var customer in customers)
        {
            if (customer.Id == customerId)
            {
                customers.Remove(customer);
                break;
            }
        }

        return customerId;
    }



}
