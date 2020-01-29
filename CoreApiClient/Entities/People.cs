using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;

namespace CoreApiClient.Entities
{
    public class PeopleResponse
    {
        [DataMember(Name = "count")]
        public int count { get; set; }

        [JsonProperty("next")]
        [DataMember(Name = "next")]
        public string NextPage { get; set; }

        [DataMember(Name = "previous")]
        public string previous { get; set; }

        [DataMember(Name = "results")]
        public List<People> results { get; set; }

        public PeopleResponse NextPeopleResponse { get; set; }

        public void CarregarProximaPagina()
        {


            if (NextPage == null)
                return;

            var json = new WebClient().DownloadString(NextPage);

            //HttpClient client = new HttpClient();
            //var response = client.GetAsync(NextPage);
            //var responseBody = response.Result;

            NextPeopleResponse = JsonConvert.DeserializeObject<PeopleResponse>(json);
            NextPeopleResponse.CarregarProximaPagina();
        }

        public List<People> ObterListaAgregadaPessoas()
        {
            var listaAgreagada = new List<People>();
            listaAgreagada.AddRange(results);

            if(NextPeopleResponse != null)
                listaAgreagada.AddRange(NextPeopleResponse.ObterListaAgregadaPessoas());

            return listaAgreagada;
        }
    }
    public class People
    {
        /// <summary>
        /// An array of vehicle resources that this person has piloted
        /// </summary>
        [DataMember(Name = "vehicles")]
        public List<string> vehicles
        {
            get;
            set;
        }

        /// <summary>
        /// The gender of this person (if known).
        /// </summary>
        [DataMember(Name = "gender")]
        public string gender
        {
            get;
            set;
        }

        /// <summary>
        /// The url of this resource
        /// </summary>
        [DataMember(Name = "url")]
        public string url
        {
            get;
            set;
        }

        /// <summary>
        /// The height of this person in meters.
        /// </summary>
        [DataMember(Name = "height")]
        public string height
        {
            get;
            set;
        }

        /// <summary>
        /// The hair color of this person.
        /// </summary>
        [DataMember(Name = "hair_color")]
        public string hair_color
        {
            get;
            set;
        }

        /// <summary>
        /// The skin color of this person.
        /// </summary>
        [DataMember(Name = "skin_color")]
        public string skin_color
        {
            get;
            set;
        }

        /// <summary>
        /// An array of starship resources that this person has piloted
        /// </summary>
        [DataMember(Name = "starships")]
        public List<string> starships
        {
            get;
            set;
        }

        /// <summary>
        /// The name of this person.
        /// </summary>
        [DataMember(Name = "name")]
        public string name
        {
            get;
            set;
        }

        /// <summary>
        /// An array of urls of film resources that this person has been in.
        /// </summary>
        [DataMember(Name = "films")]
        public List<string> films
        {
            get;
            set;
        }

        public List<string> filmsPeople
        {
            get;
            set;
        }

        /// <summary>
        /// The birth year of this person. BBY (Before the Battle of Yavin) or ABY (After the Battle of Yavin).
        /// </summary>
        [DataMember(Name = "birth_year")]
        public string birth_year
        {
            get;
            set;
        }

        /// <summary>
        /// The url of the planet resource that this person was born on.
        /// </summary>
        [DataMember(Name = "homeworld")]
        public string homeworld
        {
            get;
            set;
        }

        /// <summary>
        /// The url of the species resource that this person is.
        /// </summary>
        [DataMember(Name = "species")]
        public List<string> species
        {
            get;
            set;
        }

        /// <summary>
        /// The eye color of this person.
        /// </summary>
        [DataMember(Name = "eye_color")]
        public string eye_color
        {
            get;
            set;
        }

        /// <summary>
        /// The mass of this person in kilograms.
        /// </summary>
        [DataMember(Name = "mass")]
        public string mass
        {
            get;
            set;
        }

        [DataMember(Name = "created")]
        public string created
        {
            get;
            set;
        }

        [DataMember(Name = "edited")]
        public string edited
        {
            get;
            set;
        }
    }
}