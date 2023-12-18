using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8AssignmentPart2
{
    internal class Program
    {
        static DataTable Create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PId", typeof(string));
            dt.Columns.Add("PName", typeof(string));
            dt.Columns.Add("PPrice", typeof(int));
            dt.Columns.Add("mfgDate", typeof(DateTime));
            dt.Columns.Add("expDate", typeof(DateTime));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["PId"] };
            return dt;
        }
        static void insert(DataTable dt, string pid, string pname, int price, DateTime mfgdate, DateTime expdate)
        {
            DataRow dr = dt.NewRow();
            dr["PId"] = pid;
            dr["PName"] = pname;
            dr["PPrice"] = price;
            dr["mfgDate"] = mfgdate;
            dr["expDate"] = expdate;
            dt.Rows.Add(dr);
            Console.WriteLine($"Record inserted for Id {pid}!!!");
        }
        static void search(DataTable dt, string pid)
        {
            DataRow foundRow = dt.Rows.Find(pid);
            if (foundRow == null)
            {
                Console.WriteLine($"No such id{pid} exist");
            }
            else
            {
                Console.WriteLine("Record Found Details as Follows");
                Console.WriteLine($"PID:\t {foundRow["PId"]}");
                Console.WriteLine($"Product Name:\t {foundRow["PName"]}");
                Console.WriteLine($"Product Price:\t {foundRow["PPrice"]}");
                Console.WriteLine($"mfg date:\t {foundRow["mfgDate"]}");
                Console.WriteLine($"exp date:\t {foundRow["expDate"]}");
            }
        }
        static void Delete(DataTable dt, string pid)
        {
            DataRow delRow = dt.Rows.Find(pid);
            if (delRow == null)
            {
                Console.WriteLine($"No such id {pid} exist");
            }
            else
            {
                dt.Rows.Remove(delRow);
                Console.WriteLine($"Record with Id {pid} deleted from table");
            }
        }
        static void Update(DataTable dt, string pid, string pname, int price,DateTime mfgdate, DateTime expdate)
        {
            DataRow updateRow = dt.Rows.Find(pid);
            if (updateRow != null)
            {
                updateRow["PName"] = pname;
                updateRow["PPrice"] = price;
                updateRow["mfgDate"] = mfgdate;
                updateRow["expDate"] = expdate;

            }
            else
            {
                Console.WriteLine($"No Such Id {pid} exist");
            }
        }
        static void Display(DataTable dt)
        {
            Console.WriteLine("Stored Current Data in Table");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("PID: \t" + row["PId"]);
                Console.WriteLine("Product Name: \t" + row["PName"]);
                Console.WriteLine("Product Price: \t" + row["PPrice"]);
                Console.WriteLine($"mfg date: \t" + row["mfgDate"]);
                Console.WriteLine($"exp date: \t" + row["expDate"]);
                Console.WriteLine("------------------------------------------");
            }
        }
        static void Main(string[] args)
        {
            DataTable dt = Create();
            insert(dt,"P00001", "Shampoo", 560, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00002", "Perfume", 4500, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00003", "Powder", 350, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00004", "Lipstic", 850, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00005", "Shampoo", 450, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00006", "Conditioner", 865, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00007", "Moisturizer", 250, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00008", "Sunscreen", 1250, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00009", "Detergent", 665, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            insert(dt,"P00010", "face cream", 785, new DateTime(day: 12, month: 12, year: 2022), new DateTime(day: 09, month: 12, year: 2023));
            Display(dt);
            Console.WriteLine("Enter ID to delete the Data Row");
            string DelId =Console.ReadLine();
            Delete(dt, DelId);
            Console.WriteLine("After Delete Method Call Table");
            Display(dt);
            Console.WriteLine("Enter ID to search the Data Row");
            string SId = Console.ReadLine();
            search(dt, SId);
            Console.WriteLine("Enter ID to update the Data Row");
            string pid = Console.ReadLine();
            Console.WriteLine("Enter New First Name");
            string newPname = Console.ReadLine();
            Console.WriteLine("Enter New Last Name");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Salary");
            DateTime newmfgDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Date of Joining");
            DateTime newexpDate = DateTime.Parse(Console.ReadLine());
            Update(dt, pid, newPname, price, newmfgDate, newexpDate);
            Console.WriteLine("*******After Update Method Call********");
            Display(dt);
            Console.ReadKey();
        }
    }
}

