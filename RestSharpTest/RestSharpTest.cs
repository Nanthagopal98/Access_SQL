using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestSharpTest
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
    }
    [TestClass]
    public class RestSharpTest
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }
        private RestResponse getEmployeeList()
        {
            //arange
            RestRequest request = new RestRequest("/employees", Method.Get);

            //act
            RestResponse response = client.Execute(request);
            return response;
        }
        [TestMethod]
        public void CallintApi_ReturnEmployeeList()
        {
            RestResponse resopnse = getEmployeeList();
            //Assert
            Assert.AreEqual(resopnse.StatusCode, HttpStatusCode.OK);
            List<Employees> data = JsonConvert.DeserializeObject<List<Employees>>(resopnse.Content);
            Assert.AreEqual(7, data.Count);
        }
        [TestMethod]
        public void OnPostingEmployeeData_ShouldAddtoJsonServer()
        {
            //Arrange
            RestRequest request = new RestRequest("/employees", Method.Post);
            var input = new Employees { Name = "Kavi", Salary = 50000 };
            request.AddParameter("application/json", input, ParameterType.RequestBody);
            //Act
            RestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employees data = JsonConvert.DeserializeObject<Employees>(response.Content);
            Assert.AreEqual("Kavi", data.Name);
            Assert.AreEqual(50000, data.Salary);
            Console.WriteLine(response.Content);
        }
        [TestMethod]
        public void AddMultipleEmployees_ShouldAddtoJsonServer()
        {
            Employees emp = new Employees();
            List<Employees> list = new List<Employees>();
            list.Add(new Employees { Name = "Muthu", Salary = 30000 });
            list.Add(new Employees { Name = "Madhu", Salary = 40000 });           
            RestResponse getresponse = getEmployeeList();
            List<Employees> PresentData = JsonConvert.DeserializeObject<List<Employees>>(getresponse.Content);
            int count = PresentData.Count;

            list.ForEach(data =>
            {
                RestRequest request = new RestRequest("/employees", Method.Post);
                request.AddParameter("application/json", data, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                count++;
            });
            Assert.AreEqual(10, count);
        }
        [TestMethod]
        public void GivenUpdatedDetail_ShouldUpdateInServer()
        {
            var input = new Employees { Name = "Nanthagopal", Salary = 25000 };
            RestRequest request = new RestRequest("/employees/1", Method.Put);
            request.AddParameter("application/json", input, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Employees list = JsonConvert.DeserializeObject<Employees>(response.Content);
            Assert.AreEqual(input.Name, list.Name);
            Assert.AreEqual(input.Salary, list.Salary);
        }
    }
}