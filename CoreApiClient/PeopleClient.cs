using CoreApiClient.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApiClient
{
    public partial class ApiClient
    {
        public async Task<List<People>> GetAllPeople()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "people/"));

            PeopleResponse peopleResponse;
        
            peopleResponse = new PeopleResponse();
            peopleResponse = await GetAsync<PeopleResponse>(requestUrl);

            peopleResponse.CarregarProximaPagina();

            //List<People> listPeople = new List<People>();
            //listPeople = peopleResponse.ObterListaAgregadaPessoas().;
            //listPeople.AddRange(peopleResponse.results);

            //} while (peopleResponse.next != null);

            //return listPeople.OrderByDescending(x => x.films.Count).ThenBy(x => x.name).ToList();
            return peopleResponse.ObterListaAgregadaPessoas().OrderByDescending(x => x.films.Count).ThenBy(x => x.name).ToList();
        }

        public async Task<People> GetPeopleById(int id)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                 "people/" + id));

            return await GetAsync<People>(requestUrl);
        }

        public async Task<List<People>> GetAllHumanPeople()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "people/"));

            PeopleResponse peopleResponse;
            
            peopleResponse = new PeopleResponse();
            peopleResponse = await GetAsync<PeopleResponse>(requestUrl);

            peopleResponse.CarregarProximaPagina();

            //List<People> listPeople = new List<People>();

            return peopleResponse.ObterListaAgregadaPessoas().Where(x => x.species.Contains("https://swapi.co/api/species/1/")).ToList();

        }




    }
}
