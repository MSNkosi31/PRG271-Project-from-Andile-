using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.JobFinder
{
    public class JobFinderService : IJobFinder
    {
        public void AddEmployer(List<Employer> employers)
        {
            Console.Clear();
            Console.WriteLine("======Adding Employeer======");
            Console.Write("Enter Employer Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Contact Number: ");
            int contactNo = int.Parse(Console.ReadLine());

            Employer employer = new Employer
            {
                Name = name,
                ContactNo = contactNo
            };
            employers.Add(employer);

            Console.Clear();
            Console.WriteLine("*******Employer added successfully.*******");
            Thread.Sleep(1500);
            Console.Clear();
        }

        public void AddApplicant(List<Applicant> applicants)
        {
            Console.Clear();
            Console.WriteLine("======Adding Application======");
            Console.Write("Enter Applicant Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Applicant Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Resume Information: ");
            string resume = Console.ReadLine();

            string CV = null;
            Applicant applicant = new Applicant
            {
                Name = name,
                Email = email,
                CV = CV,
            };
            applicants.Add(applicant);

            Console.Clear();
            Console.WriteLine("*******Applicant added successfully.*******");
            Thread.Sleep(1500);
            Console.Clear();
        }

        public void AddJob(List<Job> jobs)
        {
            Console.Clear();
            Console.WriteLine("======Listing A Job======");
            Console.Write("Enter Job Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Job Description: ");
            string description = Console.ReadLine();

            Console.Write("Enter Employer Name: ");
            string employerName = Console.ReadLine();

            Job job = new Job
            {
                Title = title,
                Description = description,
                EmployerName = employerName
            };

            jobs.Add(job);

            Console.Clear();
            Console.WriteLine("*******Job added successfully.*******");
            Thread.Sleep(1500);
            Console.Clear();
        }

        public void ListEmployers(List<Employer> employers)
        {
            Console.Clear();
            Console.WriteLine("======List Of Employers======");
            if (employers != null)
            {
                foreach (var employer in employers)
                {
                    Console.WriteLine(employer);
                }
            }
            else
            {
                Console.WriteLine("******No employers found******");
                Thread.Sleep(1500);

            }
            Console.Clear();
        }

        public void ListApplicants(List<Applicant> applicants)
        {
            Console.Clear();
            Console.WriteLine("======List Of Applicants======");
            if (applicants != null)
            {
                foreach (var applicant in applicants)
                {
                    Console.WriteLine(applicant);
                }
            }
            else
            { 
                Console.WriteLine("******No applicants found******");
                Thread.Sleep(1500);
            }
            Console.Clear();
        }

        public void ListJobs(List<Job> jobs)
        {
            Console.Clear();
            Console.WriteLine("======List Of Jobs======");
            if (jobs != null)
            {
                foreach (var job in jobs)
                {
                    Console.WriteLine(job);
                }
            }
            else
            { 
                Console.WriteLine("******No joblisting found******");
                Thread.Sleep(1500);
            }
            Console.Clear();
        }
    }
}