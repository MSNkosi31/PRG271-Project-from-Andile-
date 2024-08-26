using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.JobFinder
{
    public class JobFinderService : IJobFinder
    {
        public void AddEmployer(List<Employer> employers)
        {
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
            Console.WriteLine("Employer added successfully.");
        }

        public void AddApplicant(List<Applicant> applicants)
        {
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
            Console.WriteLine("Applicant added successfully.");
        }

        public void AddJob(List<Job> jobs)
        {
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
            Console.WriteLine("Job added successfully.");
        }

        public void ListEmployers(List<Employer> employers)
        {
            Console.WriteLine("\nList of Employers:");
            foreach (var employer in employers)
            {
                Console.WriteLine(employer);
            }
        }

        public void ListApplicants(List<Applicant> applicants)
        {
            Console.WriteLine("\nList of Applicants:");
            foreach (var applicant in applicants)
            {
                Console.WriteLine(applicant);
            }
        }

        public void ListJobs(List<Job> jobs)
        {
            Console.WriteLine("\nList of Jobs:");
            foreach (var job in jobs)
            {
                Console.WriteLine(job);
            }
        }
    }
}