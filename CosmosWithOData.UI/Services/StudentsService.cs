using CosmosWithOData.UI.Brokers;
using CosmosWithOData.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosWithOData.UI.Services
{
    public class StudentsService
    {
        private string nextLink;
        private StudentsApiBroker studentsApiBroker;

        public StudentsService()
        {
            this.nextLink = null;
            this.studentsApiBroker = new StudentsApiBroker();
        }

        public async Task<List<Student>> GetStudents()
        {
            var response = await this.studentsApiBroker.GetStudentsAsync(nextLink);
            this.nextLink = response.NextLink;

            return response.Students;
        }
    }
}
