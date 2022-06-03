using System;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Newtonsoft.Json;

namespace Day_28_Addressook_Using_CSVndJSON
{
    public class AddressBook
    {
        //creating Generic Dictionary object
        Dictionary<string, List<Contact>> Book = new Dictionary<string, List<Contact>>();

        // method to take contact info
        public Object AddContact()
        {
            List<Contact> addContact = new List<Contact>(); //creating generic List for storing contacts info
            Console.Write("\nHow many contacts do you want to add :- ");
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 1;
            while (num > 0)
            {
                Console.Write("\nEnter the contact Details For Contact {0} \n", count);
                Contact obj = new Contact();     //creating obj of Contact class to pass info taken fromuser and intinalize them
                Console.Write("> Enter Firstname :- ");
                obj.FirstName = Console.ReadLine();
                Console.Write("> Enter Lastname :- ");
                obj.LastName = Console.ReadLine();

                Console.Write("> Enter Address :- ");
                obj.Address = Console.ReadLine();

                Console.Write("> Enter City :- ");
                obj.City = Console.ReadLine();

                Console.Write("> Enter State :- ");
                obj.State = Console.ReadLine();

                Console.Write("> Enter pincode :- ");
                obj.Zip = Convert.ToInt32(Console.ReadLine());

                Console.Write("> Enter PhoneNumber :- ");
                obj.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                Console.Write("> Enter Email :- ");
                obj.Email = Console.ReadLine();

                // >> UC7 : To avoid duplicate contact entries in AddressBook //
                //------------------------------------------------------------//
                if (addContact.Count > 0)
                {
                    foreach (var element in addContact)
                    {
                        if (element.FirstName.ToLower() != obj.FirstName.ToLower() || element.LastName.ToLower() != obj.LastName.ToLower())
                        {
                            addContact.Add(obj); //Adding obj holding all info of current user we are adding it to List
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nThis contact is already in Address Book....");
                            Console.WriteLine("Enter the details again...");
                            num++;
                            count--;
                        }
                    }
                }
                else
                {
                    addContact.Add(obj); //Adding obj holding all info of current user we are adding it to List
                }
                num--;
                count++;
            }

            // >> UC 11 & 12 :sorting contact in addressBook based on name,address,city,state,Pincode etc //
            //--------------------------------------------------------------------------------------------//
            addContact.Sort((x, y) => x.FirstName.CompareTo(y.FirstName)
                                    + x.LastName.CompareTo(y.LastName)
                                    + x.Address.CompareTo(y.Address)
                                    + x.City.CompareTo(y.City)
                                    + x.State.CompareTo(y.State)
                                    + x.Zip.CompareTo(y.Zip));
            return addContact;//Returning the whole sorted List
        }
        //Method to Add AddressBook 
        public void AddBook(string Bookname)
        {
            List<Contact> addcontact = (List<Contact>)AddContact(); // implicitly caaling addcontact method which is returning List object

            if (addcontact != null)//checking weather List is null or not Null
            {
                Book.Add(Bookname, addcontact); // Adding Book to Dictionary with Key and Value as BookName and Obj returned by addcontact method 
                Console.WriteLine("\nBook Added Successfully...");
            }
            else
            {
                Console.WriteLine("\nAddressBook Creation Failed!!");
            }

        }
        //Method to display Contacts in BOOk 
        public void DisplayBookData()
        {
            if (Book.Count > 0)
            {
                GetBookNames();
                Console.Write("\nEnter the Name of AddressBook of which you want to See the Details :- ");
                string Bookname = Console.ReadLine();
                foreach (var element in Book) //Iterating elements in Book
                {
                    if (element.Key.Contains(Bookname)) // selecting only that elemet which contain BookName  That we have searching for
                    {
                        Console.WriteLine("\nRecords in AddressBook " + Bookname);
                        foreach (var data in element.Value)
                        {
                            Console.WriteLine("\nFirstName :- " + data.FirstName + "\n" + "LastName :- " + data.LastName + "\n" + "Address :- " + data.Address + "\n" + "City :- " + data.City + "\n" + "State :- " + data.State + "\n" + "Zip :- " + data.Zip + " \n" + "PhoneNumber :- " + data.PhoneNumber + "\n" + "Email :- " + data.Email + "\n");
                        }
                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine("\nSorry!! You don't have Any Book Yet...");
            }

        }

        //To get the names of All AddressBooks in Dictionary
        public void GetBookNames()
        {
            int numOfBooks = 0;
            Console.WriteLine("Books Present in Record :");
            foreach (var Books in Book)
            {
                numOfBooks++;
                Console.WriteLine(numOfBooks + ". " + Books.Key);
            }
        }

        //To AddNew Contact in Existing dictionary
        public void AddNewContact()
        {
            Console.WriteLine("\nChoose the Book in which You want to ADD New Contact :");
            GetBookNames();
            Console.Write("\nEnter Your choice :- ");
            string BookName_ToAddContact = Console.ReadLine();
            if (Book.ContainsKey(BookName_ToAddContact))
            {
                Console.Write("\nHow many contacts do you want to add :- ");
                int num = Convert.ToInt32(Console.ReadLine());
                int count = 1;
                while (num > 0)
                {
                    List<Contact> addNew_Contact = new List<Contact>(); //creating generic List for storing contacts info
                    Console.Write("\nEnter the contact Details For Contact {0} \n", count);
                    Contact obj = new Contact();     //creating obj of Contact class to pass info taken fromuser and intinalize them
                    Console.Write("> Firstname :- ");
                    obj.FirstName = Console.ReadLine();
                    Console.Write("> Enter Lastname :- ");
                    obj.LastName = Console.ReadLine();

                    Console.Write("> Enter Address :- ");
                    obj.Address = Console.ReadLine();

                    Console.Write("> Enter City :- ");
                    obj.City = Console.ReadLine();

                    Console.Write("> Enter State :- ");
                    obj.State = Console.ReadLine();

                    Console.Write("> Enter pincode :- ");
                    obj.Zip = Convert.ToInt32(Console.ReadLine());

                    Console.Write("> Enter PhoneNumber :- ");
                    obj.PhoneNumber = Convert.ToInt64(Console.ReadLine());

                    Console.Write("> Enter Email :- ");
                    obj.Email = Console.ReadLine();

                    if (addNew_Contact.Count > 0)
                    {
                        foreach (var element in addNew_Contact)
                        {
                            if (element.FirstName.ToLower() != obj.FirstName.ToLower() || element.LastName.ToLower() != obj.LastName.ToLower())
                            {
                                addNew_Contact.Add(obj); //Adding obj holding all info of current user we are adding it to List
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nThis contact is already in Address Book....");
                                Console.WriteLine("Enter the details again...");
                                num++;
                                count--;
                            }
                        }
                    }
                    else
                    {
                        addNew_Contact.Add(obj); //Adding obj holding all info of current user we are adding it to List
                    }
                    num--;
                    count++;

                    foreach (var element in Book)
                    {
                        if (element.Key.Equals(BookName_ToAddContact))
                        {
                            element.Value.AddRange(addNew_Contact);
                            element.Value.Sort((x, y) => x.FirstName.CompareTo(y.FirstName)
                                    + x.LastName.CompareTo(y.LastName)
                                    + x.Address.CompareTo(y.Address)
                                    + x.City.CompareTo(y.City)
                                    + x.State.CompareTo(y.State)
                                    + x.Zip.CompareTo(y.Zip));
                            Console.WriteLine("\nNew Contacts are added to AddressBook " + BookName_ToAddContact);
                            break;
                        }
                    }
                }
            }
        }

        //To Delete The address Book from dictionary
        public void DeleteAddressBook()
        {
            Console.WriteLine("\nChoose the Book which You want to Delete :");
            GetBookNames();
            Console.Write("\nEnter Your choice :- ");
            string BookName_ToAddContact = Console.ReadLine();
            foreach (var element in Book)
            {
                if (element.Key.Equals(BookName_ToAddContact))
                {
                    Book.Remove(BookName_ToAddContact);
                    Console.WriteLine("Book Deleted Successfully...");
                    break;
                }
            }
        }

        //>>  UC 8 : Search Conatact by CityName And State Name
        public void SearchContact_By_CityName_StateName()
        {
            Console.Write("\nEnter the city Name of contact :- ");
            string CityName_TO_Search = Console.ReadLine();
            Console.Write("\nEnter the State Name of contact :- ");
            string StateName_TO_Search = Console.ReadLine();
            Console.WriteLine("\nSearched Result :-");
            int count = 0;
            if (Book.Count > 0)
            {
                foreach (var element in Book)
                {
                    foreach (var data in element.Value)
                    {
                        if (data.City.ToLower() == CityName_TO_Search.ToLower() && data.State.ToLower() == StateName_TO_Search.ToLower())
                        {
                            count++;
                            Console.Write("\nRecord {0} : ", count);
                            Console.WriteLine("\nFirstName :- " + data.FirstName + "\n" + "LastName :- " + data.LastName + "\n" + "Address :- " + data.Address + "\n" + "City :- " + data.City + "\n" + "State :- " + data.State + "\n" + "Zip :- " + data.Zip + " \n" + "PhoneNumber :- " + data.PhoneNumber + "\n" + "Email :- " + data.Email + "\n");
                        }
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("\nNo Records Found with City Name :- {0} | State Name :- {1}", CityName_TO_Search, StateName_TO_Search);
                }
            }
            else
                Console.WriteLine("\nYou Don't have any AddressBook To search!!");
        }

        // >> UC14 : UC14_Write AddressBook Data To CSV File 
        public void WriteAddressBookData_TO_CSVFile()
        {
            string CSVFile_Containing_AddressBook_Data = @"D:\Day-28-Addressook_Using_CSVndJSON\Day-28-Addressook_Using_CSVndJSON\Utility\AddressBookData_To_CSVFile.csv";

            using (var Writer = new StreamWriter(CSVFile_Containing_AddressBook_Data))
            {
                Console.WriteLine("\nWriting Data of AddressBooks To CSV File...");
                Writer.WriteLine("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email");
                foreach (var element in Book)
                {
                    foreach (var data in element.Value)
                    {
                        Writer.WriteLine(data.FirstName + "," + data.LastName + "," + data.Address + "," + data.City + "," + data.State + "," + data.Zip + "," + data.PhoneNumber + "," + data.Email);
                    }

                }
                Console.WriteLine("\n> All AddressBooks Data are stored in CSV File Successfully...");
            }
        }

        // >> UC14 : UC14_Read AddressBook Data From CSV File using CSVhelper Library
        public void ReadAddressBookData_From_CSVFile()
        {
            string CSVFile_Containing_AddressBook_Data = @"D:\Day-28-Addressook_Using_CSVndJSON\Day-28-Addressook_Using_CSVndJSON\Utility\AddressBookData_To_CSVFile.csv";

            using (var Reader = new StreamReader(CSVFile_Containing_AddressBook_Data))  //creating obj of stream writer class to read data
            using (var ReadData_From_CSV = new CsvReader(Reader, CultureInfo.InvariantCulture)) //creating obj of csvReader class to read data from csv file with the help of streaReader obj
            {
                int count = 0;
                Console.WriteLine("\nReading Data of AddressBooks From CSV File...");
                var records = ReadData_From_CSV.GetRecords<Contact>().ToList(); // Getting all reaocrd from csv file and returning it as a List
                if (records.Count == 0)
                {
                    Console.WriteLine("\n> You don't have any data in CSV File to read!!");
                    return;
                }
                records.Sort((x, y) => x.FirstName.CompareTo(y.FirstName)   //sort the records List to print
                                   + x.LastName.CompareTo(y.LastName));
                Console.Write("\n*** Records Of AddressBook System From CSV File ***\n");
                foreach (var addressData in records)
                {
                    Console.Write("\nFirst Name :- " + addressData.FirstName);
                    Console.Write("\nLast Name :- " + addressData.LastName);
                    Console.Write("\nAddress :- " + addressData.Address);
                    Console.Write("\nCity :- " + addressData.City);
                    Console.Write("\nState :- " + addressData.State);
                    Console.Write("\nZip :- " + addressData.Zip);
                    Console.Write("\nPhone Number :- " + addressData.PhoneNumber);
                    Console.Write("\nEmail ID:- " + addressData.Email);
                    Console.WriteLine();

                }
                Console.WriteLine("\n------------------------------------------------");

            }
        }

        // >> UC15 : UC15_Write AddressBook Data To Json File using serialization
        public void WriteAddressBookData_TO_JsonFile()
        {
            string importFilePath = @"D:\Day-28-Addressook_Using_CSVndJSON\Day-28-Addressook_Using_CSVndJSON\Utility\AddressBookData_To_CSVFile.csv";
            string JsonFile_Containing_AddressBook_Data = @"D:\Day-28-Addressook_Using_CSVndJSON\Day-28-Addressook_Using_CSVndJSON\AddressDataToJasonFile.json";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Contact>().ToList();
                if (records.Count == 0)
                {
                    Console.WriteLine("\n> You don't have any data in CSV File to write it to Json FIle!!");
                    return;
                }
                Console.WriteLine("\n>> Writing Data of AddressBooks To Json File...");
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(JsonFile_Containing_AddressBook_Data))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {   
                    serializer.Serialize(writer, records);
                    
                }
               
                Console.WriteLine("\n>> All AddressBooks Data are stored in Json File Successfully...");
            }
        }

        // >> UC15 : UC15_Read AddressBook Data From Json File using Deserialization
        public void ReadAddressBookData_From_JSonFile()
        {
            string JsonFile_Containing_AddressBook_Data = @"D:\Day-28-Addressook_Using_CSVndJSON\Day-28-Addressook_Using_CSVndJSON\AddressDataToJasonFile.json";
            Console.WriteLine("\n> Reading Data of AddressBook System from Json File...");
            Console.WriteLine("\n**** Data Of AddressBook From Json File ****");
            using (StreamReader reader = new StreamReader(JsonFile_Containing_AddressBook_Data))
            {
                var jsonRead = reader.ReadToEnd();
                if(jsonRead == "")
                {
                    Console.WriteLine("\n> You don't have any data in Json File to read!!");
                    return;
                }
                List<Contact> JsonData = JsonConvert.DeserializeObject<List<Contact>>(jsonRead);
                foreach (var contact in JsonData)
                {
                    Console.Write("\nFirst Name :- " + contact.FirstName);
                    Console.Write("\nLast Name :- " + contact.LastName);
                    Console.Write("\nAddress :- " + contact.Address);
                    Console.Write("\nCity :- " + contact.City);
                    Console.Write("\nState :- " + contact.State);
                    Console.Write("\nZip :- " + contact.Zip);
                    Console.Write("\nPhone Number :- " + contact.PhoneNumber);
                    Console.Write("\nEmail ID:- " + contact.Email);
                    Console.WriteLine();
                }
            }
            Console.WriteLine("\n-------------------------------------------------------------------");

        }
    }

    
}