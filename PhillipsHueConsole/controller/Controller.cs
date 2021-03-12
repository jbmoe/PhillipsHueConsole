using Newtonsoft.Json;
using PhillipsHueConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using test.model;

namespace test.controller {
    class Controller {
        #region singleton
        private static Controller _instance;
        public static Controller GetInstance() {
            if (_instance == null) {
                _instance = new Controller();
            }
            return _instance;
        }
        private Controller() { }
        #endregion
        #region network fields
        HttpClient client = new HttpClient();
        string URL = "http://192.168.87.124/api/5plLWq0PmCMOrBATXB2CEBonBb3OsRHtsZK2n7FQ/";
        #endregion
        #region data fields
        private List<Light> lights;
        private List<Group> groups;
        #endregion
        #region properties
        public List<Light> Lights {
            get { return lights; }
            set { lights = value; }
        }

        public List<Group> Groups {
            get { return groups; }
            set { groups = value; }
        }
        #endregion

        public async Task<HttpResponseMessage> SetComponentState(HueComponent component, string property, string value) {
            // Check which type of component
            string requestUri = "";
            if (component is Group) requestUri = $"{URL}groups/{component.ComponentKey}/action";
            else if (component is Light) requestUri = $"{URL}lights/{component.ComponentKey}/state";

            // Send put request
            HttpContent content = new StringContent($"{{\"{property}\": {value}}}");
            HttpResponseMessage response = await HTTPPut(requestUri, content);

            return response;
        }

        #region network methods
        private async Task<HttpResponseMessage> HTTPPut(string url, HttpContent content) {
            HttpResponseMessage response = await client.PutAsync(url, content);
            return response;
        }
        private async Task<string> HTTPGet(string url) {
            string response = await client.GetStringAsync(url);
            return response;
        }
        #endregion
        #region initializer method
        public async Task InitializeData() {
            try {
                // initialize lights
                string responseLights = await HTTPGet(URL + "lights");
                Dictionary<int, Light> lightsIn = JsonConvert.DeserializeObject<Dictionary<int, Light>>(responseLights);
                InitializeKeyInObj(lightsIn);
                lights = lightsIn.Values.ToList();

                // initialize groups
                string responseGroups = await HTTPGet(URL + "groups");
                Dictionary<int, Group> groupsIn = JsonConvert.DeserializeObject<Dictionary<int, Group>>(responseGroups);
                InitializeKeyInObj(groupsIn);
                groups = groupsIn.Values.ToList();


                // initialize lights for groups
                InitializeLightsInGroups(groups, lights);

            } catch (HttpRequestException e) {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            
            void InitializeKeyInObj<T>(Dictionary<int, T> objs) where T : HueComponent {
                foreach (int key in objs.Keys) {
                    objs[key].ComponentKey = key;
                }
            }

            void InitializeLightsInGroups(List<Group> groups, List<Light> lights) {
                foreach (Group group in groups) {
                    List<Light> newLights = new();
                    foreach (int i in group.LightKeys) {
                        Light toAdd = lights.Find(e => e.ComponentKey == i);
                        newLights.Add(toAdd);
                    }
                    group.Lights = newLights;
                }
            }
        }
        #endregion
    }
}
