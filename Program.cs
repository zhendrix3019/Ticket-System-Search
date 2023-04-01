static void Main(string[] args)
{
    string file = "tickets.txt";
    string choice;

    do
    {
        Console.WriteLine("\n1) Read data from file.");
        Console.WriteLine("2) Create file from data.");
        Console.WriteLine("3) Search for tickets.");
        Console.WriteLine("Enter any other key to exit.");

        choice = Console.ReadLine();

        if (choice == "1")
        {
            if (File.Exists(file))
            {
                List<Ticket> tickets = ReadTicketsFromFile(file);
                foreach (Ticket ticket in tickets)
                {
                    Console.WriteLine(ticket);
                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        else if (choice == "2")
        {
            List<Ticket> tickets = new List<Ticket>();

            do
            {
                Console.WriteLine("Enter a new ticket (Y/N)?");
                choice = Console.ReadLine().ToUpper();
                if (choice != "Y") { break; }

                Console.WriteLine("Enter the type of ticket (Bug/Defect, Enhancement, Task):");
                string ticketType = Console.ReadLine();

                Ticket ticket;
                switch (ticketType)
                {
                    case "Bug/Defect":
                        ticket = CreateBugTicket();
                        break;
                    case "Enhancement":
                        ticket = CreateEnhancementTicket();
                        break;
                    case "Task":
                        ticket = CreateTaskTicket();
                        break;
                    default:
                        Console.WriteLine("Invalid ticket type, defaulting to Bug/Defect");
                        ticket = CreateBugTicket();
                        break;
                }
                tickets.Add(ticket);

            } while (choice == "Y");

            WriteTicketsToFile(file, tickets);
        }
        else if (choice == "3")
        {
            Console.WriteLine("\nSearch by:\n1) Status\n2) Priority\n3) Submitter\n");
            Console.Write("Enter the search criteria: ");
            int searchCriteria = int.Parse(Console.ReadLine());

            Console.Write("Enter the search term: ");
            string searchTerm = Console.ReadLine();

            List<Ticket> tickets = ReadTicketsFromFile(file);

            List<Ticket> searchResults = new List<Ticket>();

            foreach (Ticket ticket in tickets)
            {
                if (searchCriteria == 1 && ticket.Status == searchTerm)
                {
                    searchResults.Add(ticket);
                }
                else if (searchCriteria == 2 && ticket.Priority == searchTerm)
                {
                    searchResults.Add(ticket);
                }
                else if (searchCriteria == 3 && ticket.Submitter == searchTerm)
                {
                    searchResults.Add(ticket);
                }
            }

            if (searchResults.Count > 0)
            {
                Console.WriteLine($"\n{searchResults.Count} tickets found:");
                foreach (Ticket ticket in searchResults)
                {
                    Console.WriteLine(ticket);
                }
            }
            else
            {
                Console.WriteLine("\nNo tickets found.");
            }
        }

    } while (choice == "1" || choice == "2" || choice == "3" || choice == "N");
}