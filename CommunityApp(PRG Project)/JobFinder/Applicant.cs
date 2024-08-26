using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityApp_PRG_Project_.JobFinder
{
    internal class Applicant
    {
        private string title;
        private string email;
        private string cV;

        public Applicant()
        {
            
        }

        public Applicant(string title, string email, string cV)
        {
            this.title = title;
            this.email = email;
            this.cV = cV;
        }

        public string Title { get => title; set => title = value; }
        public string Email { get => email; set => email = value; }
        public string CV { get => cV; set => cV = value; }

        public override string ToString()
        {
            return ($"Job: {title}, Email: {email}, CV: {cV}");
        }
    }
}
